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

	int i = 0;
	string answersArr[] = { correctAnswer, answer2, answer3, answer4 };
	bool alreadyInit[] = { false, false, false, false };
	while (i < 4)
	{
		srand((unsigned int)time(NULL));
		int currAnsIndex = rand() % FOUR;
		if (!alreadyInit[currAnsIndex])
		{
			if (i == 0)
			{
				_correctAnswerIndex = currAnsIndex;
			}
			alreadyInit[currAnsIndex] = true;
			_answers[currAnsIndex] = answersArr[i];
			i++;
		}
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
