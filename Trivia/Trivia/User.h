#pragma once

#include "Helper.h"
#include "Game.h"
#include "Room.h"

class User
{
private:
	string _username;
	Room* _currRoom;
	Game* _currGame;
	SOCKET _sock;

public:
	User(string username, SOCKET sock);
	void send(string message);
	string getUsername();
	SOCKET getSocket();
	Room* getRoom();
	Game* getGame();
	void setGame(Game* gm);
	void clearGame();
	void clearRoom();
	bool createRoom(int roomId, string roomName, int maxUsers, int questionsNo, int questionTime);
	bool joinRoom(Room* newRoom);
	void leaveRoom();
	int closeRoom();
	bool leaveGame();
};