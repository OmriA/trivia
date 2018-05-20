#pragma once

#include "Helper.h"
#include "User.h"

class RecievedMessage
{
private:
	SOCKET _sock;
	User* _user;
	int _messageCode;
	vector<string> _values;

public:
	RecievedMessage(SOCKET sock, int messageCode);
	RecievedMessage(SOCKET sock, int messageCode, vector<string> values);
	~RecievedMessage() = default;
	SOCKET getSock();
	User* getUser();
	void setUser(User* user);
	int getMessageCode();
	vector<string>& getValues();

};