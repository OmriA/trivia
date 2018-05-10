#pragma once

#include "Question.h"
#include "User.h"
#include <map>

using std::map;

class Game
{
private:
	vector<Question*> _questions;
	vector<User*> _players;
	int _question_no;
	int _currQuestionIndex;
	//TODO: DataBase db&;
	map<string, int> _results;
	int _currentTurnAnswers;

public:
	Game(const vector<User*>& players, int questionsNo/*, DataBase& db*/);
};
