#include "DataBase.h"

DataBase::DataBase()
{
	int notOpenedSuccessfuly = sqlite3_open("triviaDB.db", &_db);
	if (notOpenedSuccessfuly)
	{
		throw "Didn't opened databse successfuly.";
	}
}

DataBase::~DataBase()
{
	sqlite3_close(_db);
}

bool DataBase::isUserExists(string username)
{
	sqlite3_select();
}

int DataBase::callbackCount(void* data, int argc, char** argv, char** azColName)
{
	return argc - 1;
}