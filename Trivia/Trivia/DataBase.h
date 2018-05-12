#pragma once

#include "sqlite3.h"

class DataBase
{
public:
	DataBase();
	~DataBase();
	
private:
	sqlite3 * _db;
};