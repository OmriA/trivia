#include "Helper.h"

#include <string>
#include <iomanip>
#include <sstream>
#include <iostream>
#include <fstream>

map<char, char> Helper::encMap = map<char, char>();

// recieves the type code of the message from socket (first byte)
// and returns the code. if no message found in the socket returns 0 (which means the client disconnected)
int Helper::getMessageTypeCode(SOCKET sc)
{
	char* s = getPartFromSocket(sc, 3);
	std::string msg(s);

	if (msg == "")
		return 0;

	int res = std::atoi(s);
	delete s;
	return  res;
}

// send data to socket
// this is private function
void Helper::sendData(SOCKET sc, std::string message)
{
	std::string msg = message;
	//encrypt
	for (unsigned int i = 0; i < message.length(); i++)
	{
		std::map<char, char>::iterator it;
		it = Helper::encMap.find(msg[i]);
		if (it != Helper::encMap.end())
		{
			msg[i] = it->second;
		}
	} 

	const char* data = msg.c_str();

	if (send(sc, data, msg.size(), 0) == INVALID_SOCKET)
	{
		throw std::exception("Error while sending message to client");
	}

	std::cout << "'" + msg + "' was sent to socket " + std::to_string(sc) << std::endl;
}

int Helper::getIntPartFromSocket(SOCKET sc, int bytesNum)
{
	char* s = getPartFromSocket(sc, bytesNum, 0);
	return atoi(s);
}

std::string Helper::getStringPartFromSocket(SOCKET sc, int bytesNum)
{
	char* s = getPartFromSocket(sc, bytesNum, 0);
	std::string res(s);
	return res;
}

// recieve data from socket according byteSize
// this is private function
char* Helper::getPartFromSocket(SOCKET sc, int bytesNum)
{
	return getPartFromSocket(sc, bytesNum, 0);
}

char* Helper::getPartFromSocket(SOCKET sc, int bytesNum, int flags)
{
	if (bytesNum == 0)
	{
		return nullptr;
	}

	char* data = new char[bytesNum + 1];
	int res = recv(sc, data, bytesNum, flags);

	if (res == INVALID_SOCKET)
	{
		std::string s = "Error while recieving from socket: ";
		s += std::to_string(sc);
		throw std::exception(s.c_str());
	}

	for (int i = 0; i < bytesNum; i++)
	{
		map<char, char>::iterator it = Helper::encMap.begin();
		bool found = false;
		while (it != Helper::encMap.end() && !found)
		{
			if (it->second == data[i])
			{
				it->first;
				found = true;
			}
			it++;
		}
	}
	data[bytesNum] = 0;
	return data;
}

std::string Helper::getPaddedNumber(int num, int digits)
{
	std::ostringstream ostr;
	ostr << std::setw(digits) << std::setfill('0') << num;
	return ostr.str();

}

void Helper::loadEnc()
{
	std::string line;
	std::fstream dic("../../encDic.txt");
	if (dic.is_open())
	{
		while (getline(dic, line))
		{
			encMap.insert(std::pair<char, char>(line[0], line[2]));
		}
	}
}