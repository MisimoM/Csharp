using AddressBookMaui.Model;

namespace AddressBookMaui.Service.FileService
{
    /// <summary>
    /// Service for loading/saving contacts from/to a file.
    /// </summary>
    /// <param name="contactSaver"></param>
    /// <param name="contactLoader"></param>
    public class FileService(ContactSaver contactSaver, ContactLoader contactLoader)
    {
        private readonly ContactSaver _contactSaver = contactSaver;
        private readonly ContactLoader _contactLoader = contactLoader;

        public List<ContactModel> LoadContacts()
        {
            return _contactLoader.LoadContacts();
        }

        public void SaveContacts(List<ContactModel> contacts)
        {
            _contactSaver.SaveContacts(contacts);
        }
    }
}
