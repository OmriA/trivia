#pragma once
#include<string>
using std::string;
#define ANSWER_NUM 4
class Question
{

private:
	string _question;
	string _answers[ANSWER_NUM];
	int _correctAnswerIndex;
	int _id;

public:
	Question(int id, string question, string correctAnswer, string answer2, string answer3, string answer4);
	string getQuestion();
	string* getAnswers();
	int getCorrectAnswerIndex();
	int getId();
};