using AddressBookConsole.Model;

namespace AddressBookConsole.Service.MenuService
{
    /// <summary>
    /// Gets data for a new contact and uses the InputValidator the check it the input is valid.
    /// </summary>
    public class ContactDataCapture
    {
        public static ContactModel Capture(InputValidator inputValidator)
        {
            ContactModel contact = new();

            Console.Clear();
            contact.FirstName = inputValidator.GetValidInput("Enter First Name: ", "first name");
            contact.LastName = inputValidator.GetValidInput("Enter Last Name: ", "last name");
            contact.PhoneNumber = inputValidator.GetValidInput("Enter Phone Number: ", "phone number");
            contact.Email = inputValidator.GetValidInput("Enter Email: ", "Email", true).ToLower();
            contact.StreetName = inputValidator.GetValidInput("Enter Street Name: ", "street name");
            contact.PostalCode = inputValidator.GetValidInput("Enter Postal Code: ", "postal code");
            contact.City = inputValidator.GetValidInput("Enter City: ", "city");

            return contact;
        }
    }
}
