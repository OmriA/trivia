#include "Question.h"
#include<string>
#include"DataBase.h"
#include"TriviaServer.h"
#include<exception>

using std::exception;
int questiontest()
{
	Question first = Question(1, "r u ready?", "yes", "no", "maybe", "aye aye captain");
	return 0;
}

void checkIsUserExists(DataBase* db)
{
	string username;
	cout << "Write username to check if exists: ";
	cin >> username;
	if (db->isUserExists(username))
	{
		cout << "exists" << endl;
	}
	else
	{
		cout << "not exists" << endl;
	}
}

void checkAddUser(DataBase* db)
{
	string username, password, email;
	cout << "Write username to add to db: ";
	cin >> username;
	cout << "Write password to add to db: ";
	cin >> password;
	cout << "Write email to add to db: ";
	cin >> email;
	if (!db->addNewUser(username, password, email))
	{
		cout << "Insertion failed!" << endl;
	}
}

void checkIsUserAndPassMatch(DataBase* db)
{
	string username, password;
	cout << "enter username: ";
	cin >> username;
	cout << "enter password: ";
	cin >> password;
	if (db->isUserAndPassMatch(username, password))
	{
		cout << "match" << endl;
	}
	else
	{
		cout << "doesn't match" << endl;
	}
}

int main()
{
	/*DataBase* db = new DataBase();
	checkIsUserExists(db);*/
	try
	{
		TriviaServer s;
		s.server();
	}
	catch (exception e)
	{
		cout << e.what() << endl;
	}
	return 0;
}