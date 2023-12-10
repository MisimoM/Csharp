namespace AddressBookConsole.Service.MenuService
{
    public class ContactRemovalManager
    {   
        private readonly ContactService.ContactService _contactService;
        public ContactRemovalManager(ContactService.ContactService contactService)
        {
            _contactService = contactService;
        }
        public void RemoveContact()
        {
            Console.Write("Enter the email of the contact to remove: ");
            string emailToRemove = Console.ReadLine();

            if (_contactService.RemoveContact(emailToRemove))
            {
                Console.WriteLine("Contact removed successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }
}
