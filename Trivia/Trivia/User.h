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
};