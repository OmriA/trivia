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

RecievedMessage * TriviaServer::buildRecievedMessage(SOCKET client_socket, int msgCode)
{
	//Codes without values: 201, 205, 211, 215, 217, 222, 223, 225, 299
	//Codes with valuse: 200, 203, 207, 209, 213, 219

	if (msgCode == 201 || msgCode == 205 || msgCode == 211 || msgCode == 215 ||
		msgCode == 217 || msgCode == 222 || msgCode == 223 || msgCode == 225 ||
		msgCode == 299)
	{
		return new RecievedMessage(client_socket, msgCode);
	}

	vector<string> values();
	switch (msgCode)
	{
		case 
	}
}
