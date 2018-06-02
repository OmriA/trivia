#include "DataBase.h"
#include <map>
#include <numeric>
using std::stringstream;
using std::stoi;
using std::map;
using std::pair;

int DataBase::_lastInCol = 0;
vector<int> DataBase::_idVector;
string DataBase::_questions = "";
vector<string> DataBase::_usersVector;

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
vector<Question*> DataBase::initQuestions(int questionNo)
{
	vector<Question*> q;
	char* zErrMsg = 0;
	string query = "select question_id from t_questions order by random() limit " + to_string(questionNo) + ";";
	_idVector.clear();
	int rc = sqlite3_exec(_db, query.c_str(), callbackId, 0, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		return q;
	}
	for (unsigned int i = 0; i < _idVector.size(); i++)
	{
		query = "select question from t_questions where question_id=" + to_string(_idVector[i]) + ";";
		int rc = sqlite3_exec(_db, query.c_str(), callbackQuestions, 0, &zErrMsg);
		if (rc != SQLITE_OK)
		{
			return q;
		}
		string question = _questions;
		query = "select correct_ans from t_questions where question_id=" + to_string(_idVector[i]) + ";";
		rc = sqlite3_exec(_db, query.c_str(), callbackQuestions, 0, &zErrMsg);
		if (rc != SQLITE_OK)
		{
			return q;
		}
		string correctAns = _questions;
		vector<string> answers;
		for (int j = 2; j <= 4; j++)
		{
			query = "select ans" + to_string(j) + " from t_questions where question_id=" + to_string(_idVector[i]) + ";";
			int rc = sqlite3_exec(_db, query.c_str(), callbackQuestions, 0, &zErrMsg);
			if (rc != SQLITE_OK)
			{
				return q;
			}
			answers.push_back(_questions);
		}
		Question* qu = new Question(_idVector[i], question, correctAns, answers[0], answers[1], answers[2]);
		q.push_back(qu);
	}
	return q;
}

/*
This function gets returns the best scores
Input: None
Output: A vector of the best scores
*/
//each string in vector is formatted like this: username+highest score
vector<string> DataBase::getBestScores()
{
	vector<string> best;
	char* zErrMsg = 0;
	string query = "select username from t_users;";
	//gets all the users
	_usersVector.clear();
	int rc = sqlite3_exec(_db, query.c_str(), callbackBestScores, 0, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		return best;
	}

	map<string, int> scores;
	//gets personal statuses of the users
	for (unsigned int i = 0; i < _usersVector.size(); i++)
	{
		vector<string> status = getPersonalStatus(_usersVector[i]);
		scores.insert(pair<string, int>(_usersVector[i], stoi(status[1])));
	}
	//gets the top 3 hightest scores and sorts the array
	for (int i = 0; i < 3; i++)
	{
		map<string, int>::iterator it = scores.begin();
		if (it != scores.end())
		{
			pair<string, int> max = *it;
			for (it++; it != scores.end(); it++)
			{
				if (it->second > max.second)
				{
					max = *it;
				}
			}
			best.push_back(Helper::getPaddedNumber(max.first.size(), 2) + max.first + Helper::getPaddedNumber(max.second, 6));
			scores.erase(max.first);
		}
		else
		{
			best.push_back("");
		}
	}
	return best;
}

/*
This function returns the personal status
Input: None
Output: The personal status vector
*/
//vector looks like this: first the game count, then the num of right ans,
//then the num of wrong ans, and the avg time for each question
vector<string> DataBase::getPersonalStatus(string username)
{
	vector<string> status;
	char* zErrMsg = 0;
	//gets number of games
	string query = "select count(distinct game_id) from t_players_answers where username=\"" + username + "\";";
	int rc = sqlite3_exec(_db, query.c_str(), callbackCount, 0, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		return status;
	}
	status.push_back(Helper::getPaddedNumber(_lastInCol, 4));
	//gets number of correct answers
	query = "select count(*) from t_players_answers where is_correct=1 and username=\"" + username + "\";";
	rc = sqlite3_exec(_db, query.c_str(), callbackCount, 0, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		return status;
	}
	status.push_back(Helper::getPaddedNumber(_lastInCol, 6));
	//gets number of wrong answers
	query = "select count(*) from t_players_answers where is_correct=0 and username=\"" + username + "\";";
	rc = sqlite3_exec(_db, query.c_str(), callbackCount, 0, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		return status;
	}
	status.push_back(Helper::getPaddedNumber(_lastInCol, 6));
	//gets avg number of time
	query = "select answer_time from t_players_answers where username=\"" + username + "\";";
	_lastInCol = 0;
	_idVector.clear();
	rc = sqlite3_exec(_db, query.c_str(), callbackPersonalStatus, 0, &zErrMsg);
	_lastInCol = accumulate(_idVector.begin(), _idVector.end(), 0) * 100 / _lastInCol;
	if (rc != SQLITE_OK)
	{
		return status;
	}
	status.push_back(Helper::getPaddedNumber(_lastInCol, 4));
	return status;
}

/*
This function creates a new game and returns its id
Input: None
Output: The new game ID
*/
int DataBase::insertNewGame()
{

	char* zErrMsg = 0;
	string query = "insert into t_games(status, start_time) valeus(0, \"now\");";
	int rc = sqlite3_exec(_db, query.c_str(), callbackCount, 0, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		return 0;
	}
	query = "select count(*) from t_games;";
	rc = sqlite3_exec(_db, query.c_str(), callbackCount, 0, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		return 0;
	}
	return _lastInCol;
}

/*
This function updates the game status
Input: Game id
Output: True if updated success, else false
*/
bool DataBase::updateGameStatus(int gameId)
{
	char* zErrMsg = 0;
	string query = "update t_games set status=1 and start_time=\"now\" where game_id=" + to_string(gameId) + ";";
	int rc = sqlite3_exec(_db, query.c_str(), callbackCount, 0, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		return false;
	}
	return true;
}

/*
This function adds the answer to the player
Input: The game id, the username, the anser, if it is correct and the answer time
Output: True if added, else false
*/
bool DataBase::addAnswerToPlayer(int gameId, string username, int questionId, string answer, bool isCorrect, int answerTime)
{
	char* zErrMsg = 0;
	string query = "insert into t_players_answers(game_id, username, question_id, player_answer, is_correct, answer_time) values(" + to_string(gameId) + ", \"" + username + "\", " + to_string(questionId) + ", \"" + answer + "\", " + (isCorrect ? "1" : "0") + ", " + to_string(answerTime) + ");";
	int rc = sqlite3_exec(_db, query.c_str(), callbackCount, 0, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		return false;
	}
	return true;
}

int DataBase::callbackCount(void* data, int argc, char** argv, char** azColName)
{
	_lastInCol = 0;
	for (int i = 0; i < argc; i++)
	{
		stringstream ss(argv[i]);
		ss >> _lastInCol;
	}
	return 0;
}

int DataBase::callbackQuestions(void* data, int argc, char** argv, char** azColName)
{
	_questions = "";
	for (int i = 0; i < argc; i++)
	{
		_questions = argv[i];
	}
	return 0;
}

int DataBase::callbackBestScores(void* data, int argc, char** argv, char** azColName)
{
	int i = 0;
	for (i = 0; i < argc; i++)
	{
		_usersVector.push_back(argv[i]);
	}
	return 0;
}

int DataBase::callbackPersonalStatus(void* data, int argc, char** argv, char** azColName)
{
	int x = 0, i = 0;
	for (i = 0; i < argc; i++)
	{
		stringstream ss(argv[i]);
		ss >> x;
		_idVector.push_back(x);
	}
	_lastInCol++;
	return 0;
}

int DataBase::callbackUserPass(void* data, int argc, char** argv, char** azColName)
{
	(*(string**)data)[0] = argv[0];
	(*(string**)data)[1] = argv[1];
	return 0;
}

int DataBase::callbackId(void* notUsed, int argc, char** argv, char** azCol)
{
	for (int i = 0; i < argc; i++)
	{
		_idVector.push_back(stoi(argv[i]));
	}
	return 0;
}
