#include "RecievedMessage.h"

/*
This function is the c'tor but without the values vector
Input: The socket and message code
*/
RecievedMessage::RecievedMessage(SOCKET sock, int messageCode) : _sock(sock), _messageCode(messageCode), _user(nullptr) {}

/*
This function is the c'tor with the values vector
Input: The socket, message code and the values vector
*/
RecievedMessage::RecievedMessage(SOCKET sock, int messageCode, vector<string> values) : _sock(sock), _messageCode(messageCode), _values(values), _user(nullptr) {}

/*
This function returns the socket
Input: None
Output: The socket
*/
SOCKET RecievedMessage::getSock()
{
	return _sock;
}

/*
This function returns the user
Input: None
Output: The user
*/
User* RecievedMessage::getUser()
{
	return _user;
}

/*
This function sets the user to the input user
Input: The input user
Output: None
*/
void RecievedMessage::setUser(User* user)
{
	_user = user;
}

/*
This function returns the message code
Input: None
Output: The message code
*/
int RecievedMessage::getMessageCode()
{
	return _messageCode;
}

/*
This function returns the values vector
Input: None
Output: The values vector
*/
vector<string>& RecievedMessage::getValues()
{
	return _values;
}

void RecievedMessage::setValues(vector<string> values)
{
	_values = values;
}
