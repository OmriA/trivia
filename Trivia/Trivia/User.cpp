#include "User.h"
#include "Helper.h"
/*
This function is the c'tor
Input: the username, the socket
*/
User::User(string username, SOCKET sock) : _username(username), _sock(sock), _currGame(nullptr), _currRoom(nullptr)
{}

/*
This function sends a message to user
Input: the message
Output: None
*/
void User::send(string message)
{
	Helper::sendData(this->_sock, message);
}

/*
This function returns the username
Input: None
Output: The username
*/
string User::getUsername()
{
	return this->_username;
}

/*
This function returns the socket
Input: None
Output: The socket
*/
SOCKET User::getSocket()
{
	return this->_sock;
}

/*
This function returns the current room
Input: None
Output: The current room
*/
Room* User::getRoom()
{
	return this->_currRoom;
}

/*
This function returns the current game
Input: None
Output: The current game
*/
Game* User::getGame()
{
	return this->_currGame;
}

/*
This function sets the currGame to the input gm, and currRoom to nullptr
Input: The game
Output: None
*/
void User::setGame(Game* gm)
{
	this->_currRoom = nullptr;
	this->_currGame = gm;
}

/*
This function disconnects the user from the game by changing currGame to nullptr
Input: None
Output: None
*/
void User::clearGame()
{
	this->_currGame = nullptr;
}

/*
This function changes currRoom to nullptr
Input: None
Output: None
*/
void User::clearRoom()
{
	this->_currRoom = nullptr;
}

/*
This function checks if a user is in a room and creates one if not
Input: the room id, the room name, the max number of users, the questions num, the question time
Output: true if succeeded in creating room, false otherwise
*/
bool User::createRoom(int roomId, string roomName, int maxUsers, int questionsNo, int questionTime)
{
	//Work in progress
	if (this->_currRoom != nullptr)
	{
		return false;
	}
	Room* r = new Room(roomId, this, roomName, maxUsers, questionsNo, questionTime);
	
	return true;
}

/*
This function makes the user join a room if he isn't in one
Input: The new room
Output: true if succeeded, false otherwise
*/
bool User::joinRoom(Room* newRoom)
{
	if (this->_currRoom != nullptr)
	{
		return false;
	}
	newRoom->joinRoom(this);
	return true;
}

/*
This function makes the user leave a room if he is in one
Input: None
Output: None
*/
void User::leaveRoom()
{
	//wORK IN PROGRESS
	if (this->_currRoom != nullptr)
	{
		this->_currRoom->leaveRoom(this);
		this->_currRoom = nullptr;
	}
}

/*
This function checks if user exists and if yes, it closes and frees from memory
Input: None
Output: -1 if user isn't in room, room id else
*/
int User::closeRoom()
{
	vector<User*>::iterator it;
	bool found = false;
	for (it = this->_currRoom->getUsers().begin(); it != this->_currRoom->getUsers().end(); it++)
	{
		if ((*it)->getUsername() == this->getUsername())
		{
			found = true;
		}
	}
	if (found == false)
	{
		return -1;
	}
	return this->closeRoom();
}

/*
This function makes user leave game if he is in one
Input: None
Output: true if game still works, false otherwise
*/
bool User::leaveGame()
{
	//Work in progress
}
