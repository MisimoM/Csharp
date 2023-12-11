using AddressBookConsole.Model;

namespace AddressBookConsole.Service.ContactService
{
    public class ContactService(FileService.FileService fileService)
    {
        private readonly List<ContactModel> contacts = fileService.LoadContacts();
        private readonly FileService.FileService _fileService = fileService;

        public List<ContactModel> GetContacts()
        {
            return contacts;
        }

        public void AddContact(ContactModel contact)
        {
            contacts.Add(contact);
            _fileService.SaveContacts(contacts);
        }

        public bool RemoveContact(string email)
        {
            ContactModel contactToRemove = contacts.Find(contact => contact.Email == email)!;

            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                _fileService.SaveContacts(contacts);
                return true;
            }

            return false;
        }

        public bool EmailExists(string email)
        {
            return contacts.Any(contact => contact.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
