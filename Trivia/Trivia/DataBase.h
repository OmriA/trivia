#pragma once

#include "sqlite3.h"
#include "Question.h"
#include <vector>
#include <iostream>

using std::cout;
using std::cin;
using std::endl;
using std::vector;

class User;

class DataBase
{
	static string userPass[2];
public:
	DataBase();
	~DataBase();
	bool isUserExists(string username);
	bool addNewUser(string username, string password, string email);
	bool isUserAndPassMatch(string username, string password);
	vector<Question*> initQuestions(int questionNo);
	vector<string> getBestScores();
	vector<string> getPersonalStatus(string username);
	int insertNewGame();
	bool updateGameStatus(int gameId);
	bool addAnswerToPlayer(int gameId, string username, int questionId, string answer, bool isCorrect, int answerTime);

private:
	static int callbackCount(void* data, int argc, char** argv, char**azColName);
	static int callbackQuestions(void* data, int argc, char** argv, char** azColName);
	static int callbackBestScores(void* data, int argc, char** argv, char** azColName);
	static int callbackPersonalStatus(void* data, int argc, char** argv, char** azColName);
	static int callbackUserPass(void* data, int argc, char** argv, char** azColName);

	sqlite3 * _db;
};