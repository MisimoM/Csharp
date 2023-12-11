using AddressBookConsole.Model;

namespace AddressBookConsole.Service.MenuService
{
    public class ContactRegistrationManager(ContactService.ContactService contactService, InputValidator inputValidator)
    {
        private readonly ContactService.ContactService _contactService = contactService;
        private readonly InputValidator _inputValidator = inputValidator;

        public void AddContact()
        {
            ContactModel contact = ContactDataCapture.Capture(_inputValidator);
            _contactService.AddContact(contact);
            Console.WriteLine("Contact added successfully.");
        }
    }
}
