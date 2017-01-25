using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace EZLF.Class
{
    public class AccountManagement
    {

        /// <summary>
        /// Validates a user's password against the password settings and determines any errors.
        /// </summary>
        /// <param name="password">The desired password. If blank then the function checks against users current password</param>
        /// <returns>
        /// Returns a list of descriptions of improvements that would need to be made to this 
        /// password for it to be valid under the password settings.  If the password is 
        /// valid under the password settings, a 0-length array is returned.
        /// </returns>
        public static List<string> ValidatePasswordAgainstSettings(string password = "")
        {
            List<string> errors = new List<string>();

            Regex matchUppercase = new Regex("[A-Z]+", RegexOptions.None);
            Regex matchLowercase = new Regex("[a-z]+", RegexOptions.None);
            Regex matchNumericDigit = new Regex("[0-9]+", RegexOptions.None);

            List<string> passwordHistory = new List<string>();
            int passwordMinChars = 8;
            //string[] commonPasswordsContained = GetCommonPasswordsContainedInString(password);


            if (password.Length < passwordMinChars)
            {
                errors.Add("Your password must be at least " + passwordMinChars + " characters long.");
            }

            if (password.Contains(" "))
            {
                errors.Add("Your password may not contain spaces.");
            }
          

            bool containsAlphaNum = true;

            if (!matchUppercase.IsMatch(password) && !matchLowercase.IsMatch(password))
            {
                containsAlphaNum = false;
                //errors.Add("Your password must contain at least one alpha character.");
            }

            if (!matchNumericDigit.IsMatch(password))
            {
                containsAlphaNum = false;
                //errors.Add("Your password must contain at least one numeric digit.");
            }
            if (!containsAlphaNum)
                errors.Add("Your password must contain at least one character and one numeric digit.");


            return errors;
        }
    }
}