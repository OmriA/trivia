#include "TriviaServer.h"

/**
C'tor to TriviaServer.
Input: None.
Output: None.
**/
TriviaServer::TriviaServer()
{
	_db = new DataBase();
	WSADATA wsa;
	WSAStartup(MAKEWORD(2, 2), &wsa);
	_socket = ::socket(AF_INET, SOCK_STREAM, 0);

	if (_socket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__ " - socket");

}

/**
D'tor to TriviaServer.
Input: None.
Output: None.
**/
TriviaServer::~TriviaServer()
{
	delete _db;
	try
	{
		::closesocket(_socket);
	}
	catch (...) {}
}

/**
The function setting up the server and managing it.
Input: None.
Output: None.
**/
void TriviaServer::server()
{
	thread messagesHandler(&TriviaServer::handleRecievedMessages, this);
	messagesHandler.detach();
	bindAndListen();
}

/**
The function listening to incoming clients.
Input: None.
Output: None.
**/
void TriviaServer::bindAndListen()
{
	struct sockaddr_in sa = { 0 };

	sa.sin_port = htons(SERVER_PORT);
	sa.sin_family = AF_INET;
	sa.sin_addr.s_addr = INADDR_ANY;

	if (::bind(_socket, (struct sockaddr*)&sa, sizeof(sa)) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - bind");

	if (::listen(_socket, SOMAXCONN) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - listen");

	while (true)
	{
		accept();
	}
}

/**
The function accepting clients.
Input: None.
Output: None.
**/
void TriviaServer::accept()
{
	SOCKET client_socket = ::accept(_socket, NULL, NULL);
	if (client_socket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__);

	thread(&TriviaServer::clientHandler, this, client_socket).detach();
}

/**
The function is handling with each client.
Input: the clients socket.
Output: none.
**/
void TriviaServer::clientHandler(SOCKET client_socket)
{
	cout << "Client has connected (Socket " + to_string(client_socket) + ")" << endl;
	try
	{
		while (true)
		{
			int msgCode = Helper::getMessageTypeCode(client_socket);
			addRecievedMessage(buildRecievedMessage(client_socket, msgCode));
		}
	}
	catch (const std::exception&)
	{
		safeDeleteUser(&RecievedMessage(client_socket, 0));
		::closesocket(client_socket);
		cout << "client Disconnected (Socket " + to_string(client_socket) + ")" << endl;
	}
}

/**
The function deleting user from the connected user safely.
Input: the recieved msg.
Output: none.
**/
void TriviaServer::safeDeleteUser(RecievedMessage * msg)
{
	cout << _connectedUsers[msg->getSock()]->getUsername() + " disconnected" << endl;
	_connectedUsers.erase(msg->getSock());
	try
	{
		::closesocket(msg->getSock());
	}
	catch (...) {}
}

/**
The function is handling sign in request. (200)
Input: the recieved message.
Output: pointer to the user if he connected successfully, nullptr if not.
**/
User * TriviaServer::handleSignin(RecievedMessage * msg)
{
	User* user = getUserByName(msg->getValues()->at(0));
	if (user != nullptr)
	{
		Helper::sendData(msg->getSock(), to_string(SIGN_IN_RESPONSE_ALREADY_CONNECTED));
		return nullptr;
	}

	if (_db->isUserAndPassMatch(((*(msg->getValues()))[0]), ((*(msg->getValues()))[1])))
	{
		return new User(msg->getValues()->at(0), msg->getSock());
	}
	else
	{
		Helper::sendData(msg->getSock(), Helper::getPaddedNumber(SIGN_IN_RESPONSE_WRONG_DETAILS, 4));
	}
	return nullptr;
}

/**
The function is handling join room request. (209)
Input: the recieved message.
Output: true if joined successfully, false if falied to join.
**/
bool TriviaServer::handleJoinRoom(RecievedMessage * msg)
{
	string answer = "110";
	int valueZero = stoi((*(msg->getValues()))[0]);
	Room* room = getRoomById(valueZero);
	User* user = getUserBySocket(msg->getSock());
	if (user == nullptr)
	{
		return false;
	}
	if (room == nullptr)
	{
		answer += "2";
	}
	else
	{
		if (user->joinRoom(room))
		{
			answer += "0";
			answer += Helper::getPaddedNumber(room->getQuestionsNo(), 2);
			answer += Helper::getPaddedNumber(room->getQuestionsTime(), 2);
		}
		else
		{
			answer += "1";
		}
	}

	Helper::sendData(msg->getSock(), answer);
	return true;
}

/**
The function is handling leave room request. (211)
Input: the recieved message.
Output: true if left room successfully, false if not.
**/
bool TriviaServer::handleLeaveRoom(RecievedMessage * msg)
{
	string answer = "1120";
	User* user = getUserBySocket(msg->getSock());
	if (user == nullptr)
	{
		return false;
	}
	Room* room = getUserBySocket(msg->getSock())->getRoom();
	if (room != user->getRoom())
	{
		return false;
	}

	user->leaveRoom();
	return true;
}

/**
The function is handling get users in room request. (207)
Input: the recieved message.
Output: none.
**/
void TriviaServer::handleGetUsersInRoom(RecievedMessage * msg)
{
	string answer = "108";
	Room* room = getRoomById(stoi(msg->getValues()->at(0)));
	if (room == nullptr)
	{
		answer += '0';
	}
	else
	{
		answer += room->getUsersListMessage();
	}

	Helper::sendData(msg->getSock(), answer);
}

/**
The function is handling the get rooms request. (205)
Input: the recieved message.
Output: none.
**/
void TriviaServer::handleGetRooms(RecievedMessage * msg)
{
	string answer = "106";
	answer += Helper::getPaddedNumber(_roomsList.size(), 4);
	if (_roomsList.size() != 0)
	{
		map<int, Room*>::iterator currRoom = _roomsList.begin();
		while (currRoom != _roomsList.end())
		{
			answer += Helper::getPaddedNumber(currRoom->second->getID(), 4);
			answer += Helper::getPaddedNumber(currRoom->second->getName().length(), 2);
			answer += currRoom->second->getName();
			currRoom++;
		}
	}

	Helper::sendData(msg->getSock(), answer);
}

/**
The function is handling the get best scores request. (223)
Input: the recieved message.
Output: none
**/
void TriviaServer::handleGetBestScores(RecievedMessage * msg)
{
	string answer = "124";
	vector<string> bestScores = _db->getBestScores();
	for (unsigned int i = 0; i < bestScores.size(); i++)
	{
		//answer += Helper::getPaddedNumber(bestScores[i].length(), 2);
		answer += bestScores[i];
	}
	if (bestScores.size() < 3)
	{
		for (unsigned int i = 0; i < 3 - bestScores.size(); i++)
		{
			answer += "0000000";
		}
	}

	Helper::sendData(msg->getSock(), answer);
}

/**
The function is handling the get personal status request. (225)
Input: the recieved message.
Output: none.
**/
void TriviaServer::handleGetPersonalStatus(RecievedMessage * msg)
{
	string answer = "126";
	vector<string> personalStatus = _db->getPersonalStatus(msg->getUser()->getUsername());
	answer += personalStatus[0] + personalStatus[1] + personalStatus[2] + personalStatus[3];

	Helper::sendData(msg->getSock(), answer);
}

bool TriviaServer::isNotEmpty() {
	return _queRecievedMessages.size() != 0;
}

/**
The function is handling all the recieved messages from the whole users.
Input: none.
Output: none
**/
void TriviaServer::handleRecievedMessages()
{
	while (true)
	{
		RecievedMessage* currMsg = nullptr;
		{
			std::unique_lock<mutex> locker(_mtxRecievedMessages);
			// critical section start
			_condRecievedMessages.wait(locker, [this] {return !_queRecievedMessages.empty(); });
			currMsg = _queRecievedMessages.front();
			_queRecievedMessages.pop();
			// critical section end
		}

		int msgCode = currMsg->getMessageCode();
		try
		{
			switch (msgCode)
			{
			case SIGN_IN_REQUEST:
			{
				User* user = handleSignin(currMsg);
				if (user != nullptr)
				{
					Helper::sendData(currMsg->getSock(), to_string(SIGN_IN_RESPONSE_SUCCESS));
					_connectedUsers.insert(std::pair<SOCKET, User*>(currMsg->getSock(), user));
					cout << currMsg->getValues()->at(0) + " connected successfully" << endl;
				}
			}
			break;
			case SIGN_OUT_REQUEST:
				cout << currMsg->getUser()->getUsername() + " disconnecting..." << endl;
				handleSignout(currMsg);
				cout << "Disconnected successfully" << endl;
				break;
			case SIGN_UP_REQUEST:
				if (handleSignup(currMsg))
				{
					cout << currMsg->getValues()->at(0) + " registered successfully" << endl;
				}
				break;
			case AVAILABLE_ROOMS_REQUEST:
				handleGetRooms(currMsg);
				break;
			case USERS_IN_ROOM_REQUEST:
				handleGetUsersInRoom(currMsg);
				break;
			case ROOM_JOIN_REQUEST:
				handleJoinRoom(currMsg);
				break;
			case ROOM_LEAVE_REQUEST:
				if (handleLeaveRoom(currMsg))
				{
					Helper::sendData(currMsg->getSock(), to_string(ROOM_LEAVE_SUCCESS));
				}
				break;
			case ROOM_CREATE_REQUEST:
				if (handleCreateRoom(currMsg))
				{
					cout << "Room " << to_string(_roomIDaux - 1) + " has created by " + currMsg->getUser()->getUsername() << endl;
				}
				break;
			case ROOM_CLOSE_REQUEST:
				handleCloseRoom(currMsg);
				break;
			case GAME_START:
				handleStartGame(currMsg);
				break;
			case ANSWER:
				handlePlayerAnswer(currMsg);
				break;
			case GAME_LEAVE:
				handleLeaveGame(currMsg);
				break;
			case BEST_SCORES_REQUEST:
				handleGetBestScores(currMsg);
				break;
			case PERSONAL_STATUS_REQUEST:
				handleGetPersonalStatus(currMsg);
				break;
			case EXIT_APPLICATION:
				safeDeleteUser(currMsg);
				break;
			default:
				safeDeleteUser(currMsg);
				break;
			}
		}
		catch (...)
		{
			safeDeleteUser(currMsg);
		}

		delete currMsg;
	}
}

/**
The function adding a recieved message the the recieved messages queue.
Input: the recieved message to add.
Output: none
**/
void TriviaServer::addRecievedMessage(RecievedMessage * msg)
{
	// critical section start
	std::lock_guard<mutex> lock(_mtxRecievedMessages);
	_queRecievedMessages.push(msg);
	// critical section end
	_condRecievedMessages.notify_all();
}

/**
The function builds a recieved message object.
Input: the client socket and the msg code.
Output: pointer to the new recieved message.
**/
RecievedMessage * TriviaServer::buildRecievedMessage(SOCKET client_socket, int msgCode)
{
	//Codes without values: 201, 205, 211, 215, 217, 222, 223, 225, 299
	//Codes with valuse: 200, 203, 207, 209, 213, 219

	RecievedMessage* output = new RecievedMessage(client_socket, msgCode);
	output->setUser(getUserBySocket(client_socket));

	if (msgCode == SIGN_OUT_REQUEST || msgCode == AVAILABLE_ROOMS_REQUEST ||
		msgCode == ROOM_LEAVE_REQUEST || msgCode == ROOM_CLOSE_REQUEST ||
		msgCode == GAME_START || msgCode == GAME_LEAVE ||
		msgCode == BEST_SCORES_REQUEST || msgCode == PERSONAL_STATUS_REQUEST ||
		msgCode == EXIT_APPLICATION)
	{
		return output;
	}

	vector<string> values;
	switch (msgCode)
	{
	case SIGN_IN_REQUEST:
		values.push_back(Helper::getStringPartFromSocket
		(client_socket, Helper::getIntPartFromSocket(client_socket, 2))); //umame

		values.push_back(Helper::getStringPartFromSocket
		(client_socket, Helper::getIntPartFromSocket(client_socket, 2))); //pass
		break;

	case SIGN_UP_REQUEST:
		values.push_back(Helper::getStringPartFromSocket
		(client_socket, Helper::getIntPartFromSocket(client_socket, 2))); //uname

		values.push_back(Helper::getStringPartFromSocket
		(client_socket, Helper::getIntPartFromSocket(client_socket, 2))); //pass

		values.push_back(Helper::getStringPartFromSocket
		(client_socket, Helper::getIntPartFromSocket(client_socket, 2))); //email
		break;

	case USERS_IN_ROOM_REQUEST:
	case ROOM_JOIN_REQUEST:
		values.push_back(Helper::getStringPartFromSocket(client_socket, 4)); //room id
		break;

	case ROOM_CREATE_REQUEST:
		values.push_back(Helper::getStringPartFromSocket
		(client_socket, Helper::getIntPartFromSocket(client_socket, 2))); //room name.

		values.push_back(Helper::getStringPartFromSocket(client_socket, 1)); //num of players.

		values.push_back(Helper::getStringPartFromSocket(client_socket, 2)); //num of questions.

		values.push_back(Helper::getStringPartFromSocket(client_socket, 2)); //time to answer.
		break;

	case ANSWER:
		values.push_back(Helper::getStringPartFromSocket(client_socket, 1)); //answer num

		values.push_back(Helper::getStringPartFromSocket(client_socket, 2)); //time in secs
		break;

	default:
		break;
	}

	output->setValues(values);
	return output;
}

/**
The function returns pointer to the user with the name that the function gets.
Input: the user's name.
Output: pointer to user with this name, nullptr if there is no user with this name.
**/
User * TriviaServer::getUserByName(string name)
{
	map<SOCKET, User*>::iterator currUser = _connectedUsers.begin();
	while (currUser != _connectedUsers.end() && currUser->second->getUsername() != name)
	{
		currUser++;
	}
	if (currUser == _connectedUsers.end())
	{
		return nullptr;
	}
	return currUser->second;
}

/**
The function gets a socket and finds a user by the socket.
Input: the socket.
Ouptut: pointer to the user if exists, if not returns nullptr.
**/
User * TriviaServer::getUserBySocket(SOCKET client_socket)
{
	map<SOCKET, User*>::iterator user = _connectedUsers.find(client_socket);
	if (user == _connectedUsers.end())
	{
		return nullptr;
	}

	return user->second;
}

/**
The function gets a room id and returns pointer to the room.
Input: the room id
Output: pointer to ther room if exists, if not returns nullptr.
**/
Room* TriviaServer::getRoomById(int roomId)
{
	map<int, Room*>::iterator room = _roomsList.find(roomId);
	if (room == _roomsList.end())
	{
		return nullptr;
	}

	return room->second;
}

/**
The function is handling the sign up request. (203)
Input: the recieved message.
Output: true if succeed, false if not.
**/
bool TriviaServer::handleSignup(RecievedMessage* msg)
{
	string username = (*msg->getValues())[0];
	string password = (*msg->getValues())[1];
	string email = (*msg->getValues())[2];
	if (!Validator::isPasswordValid(password))
	{
		Helper::sendData(msg->getSock(), to_string(SIGN_UP_RESPONSE_PASS_ILLEGAL));
		return false;
	}
	if (!Validator::isUsernameValid(username))
	{
		Helper::sendData(msg->getSock(), to_string(SIGN_UP_RESPONSE_USERNAME_ILLEGAL));
		return false;
	}
	if (_db->isUserExists(username))
	{
		Helper::sendData(msg->getSock(), to_string(SIGN_UP_RESPONSE_ALREADY_EXISTS));
		return false;
	}
	if (!_db->addNewUser(username, password, email))
	{
		Helper::sendData(msg->getSock(), to_string(SIGN_UP_RESPONSE_OTHER));
		return false;
	}

	Helper::sendData(msg->getSock(), to_string(SIGN_UP_RESPONSE_SUCCESS));
	return true;
}

/**
The function is handling the sign out request. (201)
Input: the recieved message.
Output: none.
**/
void TriviaServer::handleSignout(RecievedMessage* msg)
{
	handleCloseRoom(msg);
	handleLeaveRoom(msg);
	handleLeaveGame(msg);
	_connectedUsers.erase(msg->getSock());
}

/**
The function is handling the leave game request.(222)
Input: the recieved message.
Output: none.
**/
void TriviaServer::handleLeaveGame(RecievedMessage* msg)
{
	Game* g = msg->getUser()->getGame();
	if (g)
	{
		if (!msg->getUser()->leaveGame())
		{
			delete g;
		}
	}
}

/**
The function is handling the start game request. (217)
Input: the recieved message.
Output: none.
**/
void TriviaServer::handleStartGame(RecievedMessage* msg)
{
	Game *g;
	Room* r = msg->getUser()->getRoom();
	try
	{
		g = new Game(msg->getUser()->getRoom()->getUsers(), msg->getUser()->getRoom()->getQuestionsNo(), *_db);
		map<int, Room*>::iterator it = _roomsList.begin();
		while (it != _roomsList.end() && it->second == msg->getUser()->getRoom())
		{
			it++;
		}
		_roomsList.erase(it);
		vector<User*> users = r->getUsers();
		vector<User*>::iterator itU = users.begin();
		for (itU; itU != users.end(); itU++)
		{
			(*itU)->setRoom(nullptr);
			(*itU)->setGame(g);
		}
		g->sendFirstQuestion();
	}
	catch (...)
	{
		std::cout << "Game fail!\n";
		msg->getUser()->send(to_string(GAME_FAIL));
	}
}

/**
The function is handling the player answer message. (219)
Input: the recieved message.
Output: none
**/
void TriviaServer::handlePlayerAnswer(RecievedMessage* msg)
{
	Game* g = msg->getUser()->getGame();
	if (g)
	{
		if (!(g->handleAnswerFromUser(msg->getUser(), stoi((*(msg->getValues()))[0]), stoi((*(msg->getValues()))[1]))))
		{
			if (g)
			{
				delete g;
			}
			msg->getUser()->setGame(nullptr);
		}
	}
}

/**
The function is handling the create room request. (213)
Input: the recieved message.
Output: true if succeed, false if not
**/
bool TriviaServer::handleCreateRoom(RecievedMessage* msg)
{
	User* curr = msg->getUser();
	if (curr)
	{
		vector<string>* values = msg->getValues();
		if (curr->createRoom(_roomIDaux, (*values)[0], stoi((*values)[1], nullptr, 0), stoi((*values)[2], nullptr, 0), stoi((*values)[3], nullptr, 0)))
		{
			_roomsList[_roomIDaux] = curr->getRoom();
			_roomIDaux++;
			return true;
		}
		return false;
	}
	else
	{
		return false;
	}
}

/**
The function is handling the close room request. (215)
Input: the recieved message
Output: true if closed successfully, false if not.
**/
bool TriviaServer::handleCloseRoom(RecievedMessage* msg)
{
	User* user = msg->getUser();
	if (user == nullptr)
	{
		return false;
	}
	Room* room = user->getRoom();
	if (room == nullptr)
	{
		return false;
	}
	int value = user->closeRoom();
	if (value == -1)
	{
		return false;
	}
	map<int, Room*>::iterator it = _roomsList.begin();
	while (it != _roomsList.end() && it->second != room)
	{
		it++;
	}
	_roomsList.erase(it);
	return true;
}