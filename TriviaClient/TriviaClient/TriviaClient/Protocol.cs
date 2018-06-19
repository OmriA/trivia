using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaClient
{
    static class Protocol
    {
        public const int SIGN_IN_REQUEST = 200;
        public const int SIGN_OUT_REQUEST = 201;
        public const int SIGN_IN_RESPONSE_SUCCESS = 1020;
        public const int SIGN_IN_RESPONSE_WRONG_DETAILS = 1021;
        public const int SIGN_IN_RESPONSE_ALREADY_CONNECTED = 1022;
        public const int SIGN_UP_REQUEST = 203;
        public const int SIGN_UP_RESPONSE_SUCCESS = 1040;
        public const int SIGN_UP_RESPONSE_PASS_ILLEGAL = 1041;
        public const int SIGN_UP_RESPONSE_ALREADY_EXISTS = 1042;
        public const int SIGN_UP_RESPONSE_USERNAME_ILLEGAL = 1043;
        public const int SIGN_UP_RESPONSE_OTHER = 1044;
        public const int AVAILABLE_ROOMS_REQUEST = 205;
        public const int AVAILABLE_ROOMS_RESPONSE = 106;
        public const int USERS_IN_ROOM_REQUEST = 207;
        public const int USERS_IN_ROOM_RESPONSE = 108;
        public const int ROOM_JOIN_REQUEST = 209;
        public const int ROOM_JOIN_RESPONSE_SUCCESS = 1100;
        public const int ROOM_JOIN_RESPONSE_FULL = 1101;
        public const int ROOM_JOIN_RESPONSE_OTHER = 1102;
        public const int ROOM_LEAVE_REQUEST = 211;
        public const int ROOM_LEAVE_RESPONSE = 112;
        public const int ROOM_LEAVE_SUCCESS = 1120;
        public const int ROOM_CREATE_REQUEST = 213;
        public const int ROOM_CREATE_RESPONSE_SUCCESS = 1140;
        public const int ROOM_CREATE_RESPONSE_FAIL = 1141;
        public const int ROOM_CREATE_RESPONSE_TOO_MANY_QUESTIONS = 1142;
        public const int ROOM_CLOSE_REQUEST = 215;
        public const int ROOM_CLOSE_RESPONSE = 116;
        public const int GAME_START = 217;
        public const int QUESTION = 118;
        public const int ANSWER = 219;
        public const int ANSWER_CORRECTNESS = 120;
        public const int GAME_END = 121;
        public const int GAME_LEAVE = 222;
        public const int GAME_FAIL = 1180;
        public const int BEST_SCORES_REQUEST = 223;
        public const int BEST_SCORES_RESPOND = 124;
        public const int PERSONAL_STATUS_REQUEST = 225;
        public const int PERSONAL_STATUS_RESPONSE = 126;
        public const int EXIT_APPLICATION = 299;


        public static string GetPaddedNumber(int num, int digits)
        {
            string ret = "";
            int i = 0, numDivide = num, digCount = 0;
            while (numDivide != 0)
            {
                digCount++;
                numDivide = numDivide / 10;
            }
            if (digits > digCount)
            {
                for (i = 0; i < digits - digCount; i++)
                {
                    ret += "0";
                }
                ret += num.ToString();
                return ret;
            }
            return num.ToString();
        }
    }
}
