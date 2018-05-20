#include "DataBase.h"

/**
C'tor to the DataBase class. Opens the database.
Input: None.
Output: None.
**/
DataBase::DataBase()
{
	int notOpenedSuccessfuly = sqlite3_open("triviaDB.db", &_db);
	if (notOpenedSuccessfuly)
	{
		throw "Didn't opened databse successfuly.";
	}
}

/**
D'tor to the DataBase class. Closes the database.
Input: None.
Ouptut: None.
**/
DataBase::~DataBase()
{
	sqlite3_close(_db);
}

/**
The function checks if the username exists in the database.
Input: the username to check if exists.
Ouput: true if the user exists, false if not.
**/
bool DataBase::isUserExists(string username)
{
	string queryString = "SELECT * FROM t_users WHERE username=\"" + username + "\";";
	const char* query = queryString.c_str();
	char* errmsg = 0;

	int data = 0;
	int succeed = sqlite3_exec(_db, query, callbackCount, (void*)&data, &errmsg);
	if (succeed != SQLITE_OK)
	{
		cout << "Error! " << errmsg << endl;
		sqlite3_free(errmsg);
	}

	if (data != 0)
	{
		return true;
	}
	return false;
}

/**
The function adds new user to the database.
Input: the username, password and email.
Output: true if the insertion completed successfully, false if the insertion didn't
		complete successfully or the username was already exist.
**/
bool DataBase::addNewUser(string username, string password, string email)
{
	if (isUserExists(username))
	{
		return false;
	}
	string queryString = "INSERT INTO t_users (username, password, email) VALUES('" + username + "','" + password + "','" + email + "');";
	const char* query = queryString.c_str();
	char* errmsg = 0;
	int succeed = sqlite3_exec(_db, query, nullptr, 0, &errmsg);
	if (succeed != SQLITE_OK)
	{
		cout << "Error! " << errmsg << endl;
		sqlite3_free(errmsg);
		return false;
	}
	return true;
}

/**
The function checks if the username and the password matches to the username and the
password inside the database.
Input: the username and password to check.
Output: true if the username and the password match, false if not.
**/
bool DataBase::isUserAndPassMatch(string username, string password)
{
	if (!isUserExists(username))
	{
		return false;
	}
	string* userInfo = new string[2]; 
	string queryString = "SELECT username, password FROM t_users WHERE username='" + username + "';";
	const char* query = queryString.c_str();
	char* errmsg = 0;
	int succeed = sqlite3_exec(_db, query, callbackUserPass, &userInfo, &errmsg);
	if (succeed != SQLITE_OK)
	{
		cout << "Error! " << errmsg << endl;
		sqlite3_free(errmsg);
		return false;
	}
	bool flag = username == userInfo[0] && password == userInfo[1];
	delete[] userInfo;
	return flag;
}
/*
This function gets random questions, the amount of them is in questionNo, and creates a questions vector out of them
Input: The question number
Output: The questions vector from the questions in the db
*/
vector<Question*> initQuestions(int questionNo)
{
	
}

vector<string> getBestScores();
vector<string> getPersonalStatus(string username);
int insertNewGame();
bool updateGameStatus(int gameId);
bool addAnswerToPlayer(int gameId, string username, int questionId, string answer, bool isCorrect, int answerTime);

int DataBase::callbackCount(void* data, int argc, char** argv, char** azColName)
{
	*(int*)data = argc / 3; //dividing by because there are 3 columns.
	return 0;
}

int DataBase::callbackUserPass(void* data, int argc, char** argv, char** azColName)
{
	(*(string**)data)[0] = argv[0];
	(*(string**)data)[1] = argv[1];
	return 0;
}