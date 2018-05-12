#include "Question.h"
#include<string>
#include"DataBase.h"

int questiontest()
{
	Question first = Question(1, "r u ready?", "yes", "no", "maybe", "aye aye captain");
	return 0;
}

int main(int argc, char* argv[])
{
	DataBase* db = new DataBase();
	if (db->isUserExists("ron"))
	{
		cout << "true";
	}
	else
	{
		cout << "false";
	}
	system("PAUSE");
	return 0;
}