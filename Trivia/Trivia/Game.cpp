#include "Game.h"
#include "Protocol.h"

/*
This function is the c'tor
Input: the vector of players, the questions number, the database
*/
Game::Game(const vector<User*>& players, int questionsNo, DataBase &db) : _players(players), _db(db)
{
	_gameId = db.insertNewGame();
	_questions = db.initQuestions(questionsNo);
	for (unsigned int i = 0; i < _players.size(); i++)
	{
		_players[i]->setGame(this);
	}
}

/*
This function is the d'tor
*/
Game::~Game()
{
	_db.updateGameStatus(_gameId);
	_questions.clear();
	_players.clear();

}

/*
This function calls sendQuestionToAllUsers 
Input: None
Output: None
*/
void Game::sendFirstQuestion()
{
	sendQuestionToAllUsers();
}

/*
This function updates game status for remaining users and finishes the game
Input: None
Output: None
*/
void Game::handleFinishGame()
{
	stringstream s;
	vector<User*>::iterator it = _players.begin();
	for (it = _players.begin(); it != _players.end(); it++)
	{
		s << Helper::getPaddedNumber((**it).getUsername().length(), 2) << (**it).getUsername() << Helper::getPaddedNumber(_results[(**it).getUsername()], 2);
	}
	for (it = _players.begin(); it != _players.end(); it++)
	{
		try
		{
			(**it).send(to_string(GAME_END) + Helper::getPaddedNumber(_players.size(), 1) + s.str());
		}
		catch (...) {}
		(**it).setGame(nullptr);
	}
}

/*
This function checks if there are players, if not, finishes the game
Input: None
Output: true if game is on, false otherwise
*/
bool Game::handleNextTurn()
{
	if (_players.size() == 0)
	{
		handleFinishGame();
		return false;
	}
	if (_currentTurnAnswers == _players.size())
	{
		if (_question_no == _questions.size())
		{
			handleFinishGame();
			return false;
		}
		_question_no++;
		sendQuestionToAllUsers();
	}
	return true;
}

/*
This function increases currentTurnAnswers by 1, and handles the user's answers
Input: The user, the answer number and the time
Output: true if game hasn't ended, false if it did
*/
bool Game::handleAnswerFromUser(User* user, int answerNo, int time)
{
	this->_currentTurnAnswers++;
	if (answerNo == _questions[_question_no]->getCorrectAnswerIndex())
	{
		_results[user->getUsername()]++;
		user->send(to_string(ANSWER_CORRECTNESS) + "1");
		return handleNextTurn();
	}
	user->send(to_string(ANSWER_CORRECTNESS) + "0");
	return handleNextTurn();
}

/*
This function makes a user leave the game and if its done it also calls handle next turn
Input: Current user
Output: false
*/
bool Game::leaveGame(User* currUser)
{
	vector<User*>::iterator it = this->_players.begin();
	//way to remove from vector without a for loop
	this->_players.erase(remove(this->_players.begin(), this->_players.end(), currUser), this->_players.end());
	it = this->_players.begin();
	for (it; it != this->_players.end(); it++)
	{
		if (*it == currUser)
		{
			_players.erase(it);
			return handleNextTurn();
		}
	}
	return false;
}

/*
This function returns the game id
Input: None
Output: None
*/
int Game::getID()
{
	return this->_gameId;
}

/*
This function inserts game to db
Input: None
Output: True if succeeded, false otherwise
*/
bool Game::insertGameToDB()
{
	return _gameId = _db.insertNewGame();
}

/*
This function calls initQuestions in the db and 
Input: None
Output: None
*/
void Game::initQuestionsFromDB()
{
	vector<Question*> temp = this->_db.initQuestions(this->_question_no + 1);
	unsigned int i = 0;
	for (i = 0; i < temp.size(); i++)
	{
		_questions.push_back(temp[i]);
	}
}

/*
This function makes a 118 (send question) message and sends it to all users
Input: None
Output: None
*/
void Game::sendQuestionToAllUsers()
{
	this->_currentTurnAnswers = 0;
	unsigned int i = 0;
	string question = _questions[_question_no]->getQuestion();
	string* answers = _questions[_question_no]->getAnswers();
	stringstream message;
	string s;
	message << to_string(QUESTION) << Helper::getPaddedNumber(question.length(), 3) << question;
	for (i = 0; i < ANSWER_NUM; i++)
	{
		s = Helper::getPaddedNumber(answers[i].length(), 3);
		message << s << answers[i];
	}
	vector<User*>::iterator it = _players.begin();
	for (it; it != _players.end(); it++)
	{
		try
		{
			(**it).send(message.str());
		}
		catch (...) {}
	}
}
