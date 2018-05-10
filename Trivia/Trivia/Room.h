#pragma once

#include "User.h"
#include <vector>

using std::vector;

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
};