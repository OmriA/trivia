#include "Game.h"

/*
This function is the c'tor
Input: the vector of players, the questions number, the database
*/
Game::Game(const vector<User*>& players, int questionsNo, DataBase &db) : _players(players), _question_no(questionsNo), _db(db)
{}

/*
This function is the d'tor
*/
Game::~Game()
{}

/*
This function 
Input: None
Output: None
*/
void sendFirstQuestion();
void handleFinishGame();
bool handleNextTurn();
bool handleAnswerFromUser(User* user, int answerNo, int time);
bool leaveGame(User* currUser);
int getID();

bool insertGameToDB();
void initQuestionsFromDB();
void sendQuestionToAllUsers();
