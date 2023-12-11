using AddressBookConsole.Model;

namespace AddressBookConsole.Service.FileService
{
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
