#include "Question.h"
#include <stdlib.h>     /* srand, rand */
#include <time.h>       /* time */
#define ONE 1
#define TWO 2
#define THREE 3
#define FOUR 4

/*
This function is the c'tor
Input: the question id, the question, the correct answer, the rest of the answers 
*/
Question::Question(int id, string question, string correctAnswer, string answer2, string answer3, string answer4)
{
	this->_id = id;
	this->_question = question;
	srand((unsigned int)time(NULL));
	this->_correctAnswerIndex = rand() % FOUR;
	if (_correctAnswerIndex == 0)
	{
		_answers[0] = correctAnswer;
		_answers[ONE] = answer2;
		_answers[TWO] = answer3;
		_answers[THREE] = answer4;
	}
	if (_correctAnswerIndex == ONE)
	{
		_answers[0] = answer3;
		_answers[ONE] = correctAnswer;
		_answers[TWO] = answer4;
		_answers[THREE] = answer2;
	}
	if (_correctAnswerIndex == TWO)
	{
		_answers[0] = answer4;
		_answers[ONE] = answer2;
		_answers[TWO] = correctAnswer;
		_answers[THREE] = answer3;
	}
	if (_correctAnswerIndex == THREE)
	{
		_answers[0] = answer3;
		_answers[ONE] = answer2;
		_answers[TWO] = answer4;
		_answers[THREE] = correctAnswer;
	}

}

/*This function returns the question
Input: None
Output: the question
*/
string Question::getQuestion()
{
	return this->_question;
}

/*This function returns the answers array
Input: None
Output: the answers array
*/
string* Question::getAnswers()
{
	return this->_answers;
}

/*This function returns the correct answer index
Input: None
Output: the correct answer index
*/
int Question::getCorrectAnswerIndex()
{
	return this->_correctAnswerIndex;
}

/*This function returns the question id
Input: None
Output: the question id
*/
int Question::getId()
{
	return this->_id;
}
