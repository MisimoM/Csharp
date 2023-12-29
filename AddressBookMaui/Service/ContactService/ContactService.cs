using AddressBookMaui.Model;
using AddressBookMaui.Service.FileService;

namespace AddressBookConsole.Service.ContactService
{
    /// <summary>
    /// Service for managing contacts.
    /// </summary>
    /// <param name="fileService"></param>
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

        public void EditContact(ContactModel contact, ContactModel newContact)
        {
            RemoveContact(contact);
            AddContact(newContact);
            _fileService.SaveContacts(contacts);
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
    }
}
