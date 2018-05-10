#pragma once

#include <string>

using std::string;

class Validator
{
public:
	static bool isPasswordValid(const string pass);
	static bool isUsernameValid(const string user);
};