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
	string queryString = "SELECT * FROM t_users WHERE username=\"" + username + "\";";
	const char* query = queryString.c_str();
	char* errmsg = 0;
	
	int data = 0;
	int succeed = sqlite3_exec(_db, query, callbackCount, (void*)&data, &errmsg);
	if (succeed != SQLITE_OK)
	{
		cout << "Error! " << errmsg;
	}

	if (data != 0)
	{
		return true;
	}
	return false;
}

bool DataBase::addNewUser(string username, string password, string email)
{
	if (isUserExists(username))
	{
		return false;
	}
	string query = "INSERT INTO t_users (username, password, email) VALUES(" + username + "," + password + "," + email + ");";

}

int DataBase::callbackCount(void* data, int argc, char** argv, char** azColName)
{
	*(int*)data = argc;
	return 0;
}