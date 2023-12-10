using AddressBookConsole.Model;

namespace AddressBookConsole.Service.MenuService
{
    public class ContactValidator
    {
        public static bool Validate(ContactModel contact)
        {
            if (!FieldValidator.ValidateString(contact.FirstName))
                return false;

            if (!FieldValidator.ValidateString(contact.LastName))
                return false;

            if (!FieldValidator.ValidateString(contact.PhoneNumber))
                return false;

            if (!FieldValidator.IsValidEmail(contact.Email))
                return false;

            if (!FieldValidator.ValidateString(contact.StreetName))
                return false;

            if (!FieldValidator.ValidateString(contact.PostalCode))
                return false;

            if (!FieldValidator.ValidateString(contact.City))
                return false;

            return true;
        }

    }
}
