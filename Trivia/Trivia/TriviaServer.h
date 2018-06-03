#pragma once

#include "Helper.h"
#include "RecievedMessage.h"
#include "Protocol.h"
#include <mutex>
#include <queue>
#include <thread>
#include "Validator.h"

#define SERVER_PORT 1906
#define BUFFER_SIZE 4096

using std::mutex;
using std::condition_variable;
using std::queue;
using std::thread;
using std::stoi;

class TriviaServer
{
private:
	SOCKET _socket;
	map<SOCKET, User*> _connectedUsers;
	DataBase _db;
	map<int, Room*> _roomsList;
	int _roomIDaux;
	mutex _mtxRecievedMessages;
	condition_variable _condRecievedMessages;
	queue<RecievedMessage*> _queRecievedMessages;

	void bindAndListen();
	void accept();
	void clientHandler(SOCKET client_socket);
	void safeDeleteUser(RecievedMessage* msg);

	User* handleSignin(RecievedMessage* msg);
	bool handleSignup(RecievedMessage* msg);
	void handleSignout(RecievedMessage* msg);

	void handleLeaveGame(RecievedMessage* msg);
	void handleStartGame(RecievedMessage* msg);
	void handlePlayerAnswer(RecievedMessage* msg);

	bool handleCreateRoom(RecievedMessage* msg);
	bool handleCloseRoom(RecievedMessage* msg);
	bool handleJoinRoom(RecievedMessage* msg);
	bool handleLeaveRoom(RecievedMessage* msg);
	void handleGetUsersInRoom(RecievedMessage* msg);
	void handleGetRooms(RecievedMessage* msg);

	void handleGetBestScores(RecievedMessage* msg);
	void handleGetPersonalStatus(RecievedMessage* msg);

	void handleRecievedMessages();
	void addRecievedMessage(RecievedMessage* msg);
	RecievedMessage* buildRecievedMessage(SOCKET client_socket, int msgCode);

	User* getUserByName(string name);
	User* getUserBySocket(SOCKET client_socket);
	Room* getRoomById(int roomId);

public:
	TriviaServer();
	~TriviaServer();
	void server();
};