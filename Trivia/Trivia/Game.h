#pragma once

#include "Question.h"
#include "DataBase.h"
#include <map>

using std::map;

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
