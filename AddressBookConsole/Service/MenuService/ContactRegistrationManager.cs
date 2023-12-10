using AddressBookConsole.Model;

namespace AddressBookConsole.Service.MenuService
{
    public class ContactRegistrationManager
    {
        private readonly ContactService.ContactService _contactService;
        private readonly InputValidator _inputValidator;
        public ContactRegistrationManager(ContactService.ContactService contactService, InputValidator inputValidator)
        {
            _contactService = contactService;
            _inputValidator = inputValidator;
        }
        public void AddContact()
        {
            ContactModel contact = ContactDataCapture.Capture(_inputValidator);
            _contactService.AddContact(contact);
            Console.WriteLine("Contact added successfully.");
        }
    }
}
