using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EpsilonBank.Utilities
{
    public static class Validator
    {
        public static bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one lower case letter.";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one upper case letter.";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be lesser than 6 or greater than 15 characters.";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one numeric value.";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one special case character.";
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidateEmail(string email, out string ErrorMessage)
        {
            bool isValid = true;
            ErrorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(email))
            {
                ErrorMessage = "email can't be empty";
                isValid = false;
            }
            else if (email.Split('@').Length == 1)
            {
                ErrorMessage = "Email should contain @ symbol";
                isValid = false;
            }
            else if (email.Split('@').Length != 2)
            {
                ErrorMessage = "Email should only contain one @ symbol";
                isValid = false;
            }
            else if (email.Split('.').Length < 1)
            {
                ErrorMessage = "Email should contain atleast one . (dot)";
                isValid = false;
            }
            return isValid;
        }

        public static bool ValidateName(string name, out string errorMessage)
        {
            bool isvalid = true;
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "name can't be empty";
                isvalid = false;
            }
            else if (!char.ToUpper(name[0]).Equals(name[0]))
            {
                errorMessage = "Name must begin with capital letter";
                isvalid = false;
            }
            else if (char.IsDigit(name[0]))
            {
                errorMessage = "name must not begin with a number";
                isvalid = false;
            }
            return isvalid;
        }

        public static bool ValidateAge(string num, out string error)
        {
            bool isValid = true;
            error = string.Empty;
            float outNum;
            if (!float.TryParse(num, out outNum))
            {
                error = "invalid number";
                isValid = false;
            }
            return isValid;
        }

        public static bool ValidatePhoneNumber(string phoneNumber, out string error)
        {
            bool isValid = true;
            string strRegex = @"^[+]+234+[0-9]{10}$";
            Regex re = new Regex(strRegex);
            error = string.Empty;
            if (!re.IsMatch(phoneNumber))
            {
                isValid = false;
                error = "re-enter phone number";
                Console.WriteLine(error);
            }
            return isValid;
        }

        public static bool ValidateNumber(string num, out string error)
        {
            bool isValid = true;
            error = string.Empty;
            float outNum;
            if (!float.TryParse(num, out outNum))
            {
                error = "invalid number";
                isValid = false;
            }
            return isValid;
        }
        public static bool ValidateMoney(string num, out string error)
        {
            bool isValid = true;
            error = string.Empty;
            decimal outNum;
            if (!decimal.TryParse(num, out outNum))
            {
                error = "invalid number";
                isValid = false;
            }
            return isValid;
        }

    }
}
