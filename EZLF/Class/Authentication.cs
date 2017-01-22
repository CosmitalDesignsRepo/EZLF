using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pliner;
using Pliner.Util;

namespace EZLF.Class
{
    public class Authentication
    {
        public static string ComputePasswordHash(int userID, string password)
        {
            if (String.IsNullOrEmpty(password))
                return String.Empty;
            // compute the salt
            string userIdText = userID.ToString();
            string reversedUserIdText = String.Empty;

            for (int t = userIdText.Length - 1; t >= 0; t--)
                reversedUserIdText += userIdText[t];

            int reversedUserID = Parser.Parse(reversedUserIdText, 0);
            int lastDigitsOfUserID = userID % 100;

            int salt = (reversedUserID) * lastDigitsOfUserID;

            string saltedPassword = CharacterEncoding.SHA512EncodeString(password).Replace("-", String.Empty).Insert(userID % 128, salt.ToString());

            return CharacterEncoding.SHA512EncodeString(saltedPassword).Replace("-", String.Empty);
        }

    }
}