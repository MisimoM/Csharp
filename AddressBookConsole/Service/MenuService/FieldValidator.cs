using System.Text.RegularExpressions;

namespace AddressBookConsole.Service.MenuService
{
    /// <summary>
    /// Utility class for validating various fields.
    /// </summary>
    public class FieldValidator
    {
        public static bool ValidateString(string value)
        {
            return !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            Regex regex = new(emailPattern);

            return regex.IsMatch(email);
        }

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
