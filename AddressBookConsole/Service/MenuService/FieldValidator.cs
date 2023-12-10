using System.Text.RegularExpressions;

namespace AddressBookConsole.Service.MenuService
{
    public class FieldValidator
    {
        //Checking for empty strings
        public static bool ValidateString(string value)
        {
            return !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            Regex regex = new Regex(emailPattern);

            return regex.IsMatch(email);
        }

        // Checking for empty strings and the email regex
        public static bool ValidateEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && IsValidEmail(email);
        }

        public static bool IsNumeric(string phoneNumber)
        {
            return int.TryParse(phoneNumber, out _);
        }
    }
}
