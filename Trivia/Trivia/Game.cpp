#include "Game.h"


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
}

/*
This function 
Input: None
Output: None
*/
void sendFirstQuestion()
{

}

void handleFinishGame();
bool handleNextTurn();
bool handleAnswerFromUser(User* user, int answerNo, int time);
bool leaveGame(User* currUser);
int getID();

bool insertGameToDB();
void initQuestionsFromDB();
void sendQuestionToAllUsers();
