#include "Validator.h"

/**
Checking if the password is valid by the next rules:
- At least 4 characters.
- Does not include spaces.
- At least one digit.
- At least one Upper case letter.
- At least one Lower case letter.
Input: the password to check.
Output: true if the password is valid, false is not.
**/
bool Validator::isPasswordValid(const string pass)
{
	bool hasLower = false, hasUpper = false, hasNum = false;

	if (pass.length() < 4)
	{
		return false;
	}

	if (pass.find(" ") != string::npos)
	{
		return false;
	}

	for (unsigned int i = 0; i < pass.length(); i++)
	{
		if (pass[i] >= 'a' && pass[i] <= 'z')
		{
			hasLower = true;
		}
		else if (pass[i] >= 'A' && pass[i] <= 'Z')
		{
			hasUpper = true;
		}
		else if (pass[i] >= '0' && pass[i] <= '9')
		{
			hasNum = true;
		}
	}

	if (!hasLower || !hasUpper || !hasNum)
	{
		return false;
	}
	return true;
}

/**
Checking if the username is valid by the next rules:
- Starts with a letter.
- Does not include spaces.
- Does not empty.
Input: the username to check.
Output: true if the username is valid, false if not.
**/
bool Validator::isUsernameValid(const string user)
{
	if (user.length() == 0)
	{
		return false;
	}

	if (user.find(" ") != string::npos)
	{
		return false;
	}

	if ((user[0] >= 'a' && user[0] <= 'z') || (user[0] >= 'A' && user[0] <= 'Z'))
	{
		return true;
	}

	return false;
}