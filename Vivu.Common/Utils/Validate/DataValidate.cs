using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Vivu.Common.Utils.Validate
{
    public class DataValidate
    {
        public bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            // Regex pattern for Vietnamese phone numbers:
            // Starts with 0 followed by 9 digits, or +84 followed by 9 digits.
            string phonePattern = @"^(0|\+84)[3-9]\d{8,9}$";

            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        public bool IsValidPassword(string password)
        {
            // Regex pattern to match password between 8 and 20 characters
            // At least one uppercase letter, one lowercase letter
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z]).{8,20}$";

            return Regex.IsMatch(password, passwordPattern);
        }

        public bool IsValidUsername(string username)
        {
            // Regex pattern to match a username between 8 and 20 characters
            // It allows letters, digits, and underscores
            string usernamePattern = @"^[a-zA-Z0-9_]{8,20}$";

            return Regex.IsMatch(username, usernamePattern);
        }

    }
}
