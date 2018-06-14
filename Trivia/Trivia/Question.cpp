#include "Question.h"
#include <time.h>       /* time */
#include <algorithm>    // std::random_shuffle
#include <vector>

#define ONE 1
#define TWO 2
#define THREE 3

/*
This function is the c'tor
Input: the question id, the question, the correct answer, the rest of the answers
*/
Question::Question(int id, string question, string correctAnswer, string answer2, string answer3, string answer4)
{
	this->_id = id;
	this->_question = question;

	_answers[0] = correctAnswer;
	_answers[1] = answer2;
	_answers[2] = answer3;
	_answers[3] = answer4;

	std::random_shuffle(&_answers[0], &_answers[3]);

	int i = 0;
	while (_answers[i] != correctAnswer)
		i++;
	_correctAnswerIndex = i;
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
