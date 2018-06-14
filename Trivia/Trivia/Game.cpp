#include "Game.h"
#include "Protocol.h"

/*
This function is the c'tor
Input: the vector of players, the questions number, the database
*/
Game::Game(const vector<User*>& players, int questionsNo, DataBase &db) : _players(players), _db(db), _question_no(questionsNo - 1), _currentTurnAnswers(0)
{
	if (insertGameToDB())
	{
		initQuestionsFromDB();
		vector<User*>::iterator it = _players.begin();
		for (it; it != _players.end(); it++)
		{
			(**it).setGame(this);
			_results.insert(std::pair<string, int>((**it).getUsername(), 0));
		}
	}
	else
	{
		throw std::exception();
	}
}

/*
This function is the d'tor
*/
Game::~Game()
{
	vector<Question*>::iterator it = _questions.begin();
	for (it; it != _questions.end(); it++)
	{
		delete *it;
	}
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
	_db.updateGameStatus(getID());

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
		if (_question_no == 0)
		{
			handleFinishGame();
			return false;
		}
		_question_no--;
		_currentTurnAnswers = 0;
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
	if (answerNo == _questions[_question_no]->getCorrectAnswerIndex() + 1)
	{
		_results[user->getUsername()]++;
		_db.addAnswerToPlayer(getID(), user->getUsername(), _questions[_question_no]->getId(), _questions[_question_no]->getAnswers()[answerNo - 1], true, time);
		user->send(to_string(ANSWER_CORRECTNESS) + "1");
		return handleNextTurn();
	}
	_db.addAnswerToPlayer(getID(), user->getUsername(), _questions[_question_no]->getId(), _questions[_question_no]->getAnswers()[answerNo - 1], false, time);
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
	vector<User*>::iterator it = _players.begin();
	for (it; it != _players.end(); it++)
	{
		if (currUser == *it)
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
	_gameId = _db.insertNewGame();
	return _gameId != -1;
}

/*
This function calls initQuestions in the db and
Input: None
Output: None
*/
void Game::initQuestionsFromDB()
{
	vector<Question*> temp = _db.initQuestions(_question_no + 1);
	vector<Question*>::iterator it = temp.begin();
	for (it; it != temp.end(); it++)
	{
		_questions.push_back(*it);
	}
}

/*
This function makes a 118 (send question) message and sends it to all users
Input: None
Output: None
*/
void Game::sendQuestionToAllUsers()
{
	string question = _questions[_question_no]->getQuestion();
	string* answers = _questions[_question_no]->getAnswers();
	stringstream s;
	s << to_string(QUESTION) << Helper::getPaddedNumber(question.length(), 3) << question;
	for (int i = 0; i < 4; i++)
	{
		s << Helper::getPaddedNumber(answers[i].length(), 3) << answers[i];
	}
	vector<User*>::iterator it = _players.begin();
	for (it; it != _players.end(); it++)
	{
		try
		{
			(**it).send(s.str());
		}
		catch (...) {}
	}
}

