#include "TriviaServer.h"

/**
C'tor to TriviaServer.
Input: None.
Output: None.
**/
TriviaServer::TriviaServer()
{
	_socket = ::socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);

	if (_socket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__ " - socket");

	_db = DataBase();
}

/**
D'tor to TriviaServer.
Input: None.
Output: None.
**/
TriviaServer::~TriviaServer()
{
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

void TriviaServer::clientHandler(SOCKET client_socket)
{
	try
	{
		while (true)
		{
			int msgCode = Helper::getMessageTypeCode(client_socket);
			buildRecievedMessage(client_socket, msgCode);
		}
	}
	catch (const std::exception&)
	{
		::closesocket(client_socket);
	}
}

void TriviaServer::safeDeleteUser(RecievedMessage * msg)
{
	_connectedUsers.erase(msg->getSock());
	try
	{
		::closesocket(msg->getSock());
	}
	catch (...) {}
}

User * TriviaServer::handleSignin(RecievedMessage * msg)
{
	if (_db.isUserAndPassMatch(msg->getValues()[0], msg->getValues()[1]))
	{

	}
	try
	{
		send(msg->getSock(), Helper::getPaddedNumber(SIGN_IN_RESPONSE_WRONG_DETAILS, 4).c_str, 4, 0);
	}
	catch(...) {}
	return nullptr;
}

void TriviaServer::handleGetBestScores(RecievedMessage * msg)
{
	string answer = "124";
	vector<string> bestScores = _db.getBestScores();
	for (unsigned int i = 0; i < bestScores.size(); i++)
	{
		answer += Helper::getPaddedNumber(bestScores[i].length(), 2);
		answer += bestScores[i];
	}
}

void TriviaServer::handleGetPersonalStatus(RecievedMessage * msg)
{
	vector<string> personalStatus = _db.getPersonalStatus(msg->getUser()->getUsername());
	//TODO: create a message to send to the client and send it.
}

void TriviaServer::handleRecievedMessages()
{
	std::unique_lock<mutex> locker(_mtxRecievedMessages);
	while (true)
	{
		// critical section start
		_condRecievedMessages.wait(locker);
		RecievedMessage* currMsg = _queRecievedMessages.front();
		_queRecievedMessages.pop();
		_mtxRecievedMessages.unlock();
		// critical section end

		int msgCode = currMsg->getMessageCode();
		try
		{
			switch (msgCode)
			{
			case SIGN_IN_REQUEST:
				handleSignin(currMsg);
				break;
			case SIGN_OUT_REQUEST:
				handleSignout(currMsg);
				break;
			case SIGN_UP_REQUEST:
				handleSignup(currMsg);
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
				handleLeaveRoom(currMsg);
				break;
			case ROOM_CREATE_REQUEST:
				handleCreateRoom(currMsg);
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

void TriviaServer::addRecievedMessage(RecievedMessage * msg)
{
	// critical section start
	_mtxRecievedMessages.lock();
	_queRecievedMessages.push(msg);
	_condRecievedMessages.notify_one();
	_mtxRecievedMessages.unlock();
	// critical section end
}

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

	case USERS_IN_ROOM_REQUEST || ROOM_JOIN_REQUEST:
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

User * TriviaServer::getUserByName(string name)
{
	return nullptr;
}

User * TriviaServer::getUserBySocket(SOCKET client_socket)
{
	map<SOCKET, User*>::iterator user = _connectedUsers.find(client_socket);
	if (user == _connectedUsers.end())
	{
		return nullptr;
	}

	return user->second;
}

Room* TriviaServer::getRoomById(int roomId)
{
	map<int, Room*>::iterator room = _roomsList.find(roomId);
	if (room == _roomsList.end())
	{
		return nullptr;
	}
	
	return room->second;
}
