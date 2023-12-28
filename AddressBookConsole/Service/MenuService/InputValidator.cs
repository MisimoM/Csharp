namespace AddressBookConsole.Service.MenuService
{
    /// <summary>
    /// Handles user input with various validation checks.
    /// </summary>
    public class InputValidator(ContactService.ContactService contactService)
    {
        private readonly ContactService.ContactService _contactService = contactService;

        public string GetValidInput(string prompt, string fieldName, bool isEmail = false)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine() ?? "";

                if (isEmail && !FieldValidator.IsValidEmail(input))
                {
                    Console.WriteLine("Enter a valid email address.");
                    Console.ReadLine();
                }
                else if (!FieldValidator.ValidateString(input))
                {
                    Console.WriteLine($"Enter a valid {fieldName}.");
                    Console.ReadLine();
                }
                else if (fieldName == "phone number" && !FieldValidator.IsNumeric(input))
                {
                    Console.WriteLine($"Enter a valid {fieldName}. Use numbers only.");
                }
                else if (isEmail && _contactService.EmailExists(input))
                {
                    Console.WriteLine($"Email address {input} already exists.");
                }

            } while (
            (isEmail && !FieldValidator.IsValidEmail(input)) ||
            !FieldValidator.ValidateString(input) ||
            (isEmail && _contactService.EmailExists(input)) ||
            fieldName == "phone number" && !FieldValidator.IsNumeric(input));

            return input;
        }
    }
}
