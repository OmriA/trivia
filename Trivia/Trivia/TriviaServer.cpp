#include "TriviaServer.h"

TriviaServer::TriviaServer()
{
	_socket = ::socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);

	if (_socket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__ " - socket");

	_db = DataBase();
}

TriviaServer::~TriviaServer()
{
	try
	{
		::closesocket(_socket);
	}
	catch (...) {}
}

void TriviaServer::server()
{
	bindAndListen();
}

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

void TriviaServer::accept()
{
	SOCKET client_socket = ::accept(_socket, NULL, NULL);
	if (client_socket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__);



	thread t(&TriviaServer::clientHandler, client_socket);
	t.detach();
}

void TriviaServer::clientHandler(SOCKET client_socket)
{
}
