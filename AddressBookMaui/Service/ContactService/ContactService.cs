using AddressBookMaui.Model;
using AddressBookMaui.Service.FileService;

namespace AddressBookConsole.Service.ContactService
{
    public class ContactService(FileService fileService)
    {
        private readonly List<ContactModel> contacts = fileService.LoadContacts();
        private readonly FileService _fileService = fileService;

        public List<ContactModel> GetContacts()
        {
            return contacts;
        }

        public void AddContact(ContactModel contact)
        {
            contacts.Add(contact);
            _fileService.SaveContacts(contacts);
        }

        public void EditContact()
        {
            _fileService.SaveContacts(contacts);
        }

        public ContactModel GetContactById(Guid contactId)
        {
            return contacts.FirstOrDefault(contact => contact.Id == contactId)!;
        }

        public bool RemoveContact(ContactModel contact)
        {

            if (contact != null)
            {
                contacts.Remove(contact);
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
