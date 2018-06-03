#pragma once

#include "User.h"
#include <vector>
#include "Helper.h"
#include <algorithm>
#include "Protocol.h"
#include <sstream>
using std::vector;
using std::to_string;
using std::stringstream;
class User;

class Room
{
private:
	vector<User*> _users;
	User* _admin;
	int _maxUsers;
	int _questionTime;
	int _questionsNo;
	string _name;
	int _id;

	string getUsersAsString(vector<User*> usersList, User* excludeUser);
	void sendMessage(string message);
	void sendMessage(User* excludeUser, string message);
public:
	Room(int id, User* admin, string name, int maxUsers, int questionsNo, int questionTime);
	bool joinRoom(User* user);
	void leaveRoom(User* user);
	int closeRoom(User* user);
	vector<User*> getUsers();
	string getUsersListMessage();
	int getQuestionsNo();
	int getQuestionsTime();
	int getID();
	string getName();
};