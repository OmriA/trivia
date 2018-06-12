#include "Room.h"

/*
This function is the ctor
Input: The room id, the admin user, the room name, the max num of users, the questions number and questions time
*/
Room::Room(int id, User* admin, string name, int maxUsers, int questionsNo, int questionTime) : _id(id), _admin(admin), _name(name), _maxUsers(maxUsers), _questionsNo(questionsNo), _questionTime(questionTime)
{
	_users.push_back(admin);
}

/*
This function makes a user join a room, if already in room return false
Input: The user
Output: True if joined successfully, false if already in room
*/
bool Room::joinRoom(User* user)
{
	if (this->_users.size() < (unsigned int)_maxUsers)
	{
		this->_users.push_back(user);
		stringstream message;
		message << to_string(ROOM_JOIN_RESPONSE_SUCCESS) << Helper::getPaddedNumber(this->_questionsNo, 2) << Helper::getPaddedNumber(this->_questionTime, 2);
		user->send(message.str());
		vector<User*>::iterator it = this->_users.begin();
		for (it; it != _users.end(); it++)
		{
			(**it).send(to_string(USERS_IN_ROOM_RESPONSE) + getUsersListMessage());
		}
		return true;
	}
	user->send(to_string(ROOM_JOIN_RESPONSE_FULL));
	return false;
}
/*
This function makes a user leave a room, if he is in one, and sends to the user a leaving message and to the other users the updated user list
Input: The user
Output: None
*/
void Room::leaveRoom(User* user)
{
	vector<User*>::iterator it = this->_users.begin();
	//way to remove from vector without a for loop
	this->_users.erase(remove(this->_users.begin(), this->_users.end(), user), this->_users.end());
	it = this->_users.begin();
	for (it; it != this->_users.end(); it++)
	{
		(**it).send(to_string(USERS_IN_ROOM_RESPONSE) + getUsersListMessage());
		cout << (**it).getUsername() << " " << to_string(USERS_IN_ROOM_RESPONSE) + getUsersListMessage() << endl;
	}
}

/*
This function closes room if user is the admin
Input: The user
Output: if room is user is admin, closes room and returns id, else -1
*/
int Room::closeRoom(User* user)
{
	if (user != this->_admin)
	{
		return -1;
	}
	for (vector<User*>::iterator it = this->_users.begin(); it != this->_users.end(); ++it)
	{
		(*it)->send(to_string(ROOM_CLOSE_RESPONSE));
		(*it)->clearRoom();
	}
	return _id;
}

/*
This function returns the users vector
Input: None
Output: The users vector
*/
vector<User*> Room::getUsers()
{
	return this->_users;
}

/*
This function returns the users list
Input: None
Output: The users list in string
*/
string Room::getUsersListMessage()
{
	unsigned int i = 0;
	string userList = to_string(_users.size());
	string username = "";
	for (i = 0; i < _users.size(); i++)
	{
		username = _users[i]->getUsername();
		userList += Helper::getPaddedNumber(username.length(), 2) + username;
	}
	return userList;
}

/*
This function returns the questions number in the room
Input: None
Output: The questions number
*/
int Room::getQuestionsNo()
{
	return this->_questionsNo;
}

/**
This function returns the questions time
Input: None.
Ouput: the time for each question.
**/
int Room::getQuestionsTime()
{
	return _questionTime;
}

/*
This function returns the room id
Input: None
Output: The room id
*/
int Room::getID()
{
	return _id;
}

/*
This function returns the room name
Input: None
Output: The room name
*/
string Room::getName()
{
	return this->_name;
}

/*
This function return a string full of the user names
Input: A user to exclude, the users list
Output: The users string
*/
string Room::getUsersAsString(vector<User*> usersList, User* excludeUser)
{
	unsigned int i = 0;
	string userList = to_string(usersList.size());
	string username = "Users: ";
	for (i = 0; i < usersList.size(); i++)
	{
		username = usersList[i]->getUsername();
		if (username != excludeUser->getUsername())
		{
			userList += "\n" + username;
		}
	}
	return userList;
}

/*
This function sends a certain message to all users in room
Input: The message
Output: None
*/
void Room::sendMessage(string message)
{
	sendMessage(nullptr, message);
}

/*
This function is the same as above but you're able to exclude a user now
Input: The message, the excluded user
Output: None
*/
void Room::sendMessage(User* excludeUser, string message)
{
	for (vector<User*>::iterator it = this->_users.begin(); it != this->_users.end(); it++)
	{
		if ((*it) != excludeUser)
		{
			(*it)->send(message);
		}
	}
}
