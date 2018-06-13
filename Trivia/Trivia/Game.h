#pragma once

#include "Question.h"
#include "DataBase.h"
#include "User.h"
#include <map>
#include <sstream>
#include <string>
using std::map;
using std::stringstream;
using std::pair;
class User;
class DataBase;

class Game
{
private:
	vector<Question*> _questions;
	vector<User*> _players;
	int _question_no;
	int _currQuestionIndex;
	DataBase &_db;
	map<string, int> _results;
	int _currentTurnAnswers;
	int _gameId;

	bool insertGameToDB();
	void initQuestionsFromDB();
	void sendQuestionToAllUsers();
public:
	Game(const vector<User*>& players, int questionsNo, DataBase &db);
	~Game();
	void sendFirstQuestion();
	void handleFinishGame();
	bool handleNextTurn();
	bool handleAnswerFromUser(User* user, int answerNo, int time);
	bool leaveGame(User* currUser);
	int getID();
};
