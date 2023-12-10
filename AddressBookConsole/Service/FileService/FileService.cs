using AddressBookConsole.Model;

namespace AddressBookConsole.Service.FileService
{
    public class FileService
    {
        private readonly ContactSaver _contactSaver;
        private readonly ContactLoader _contactLoader;

        public FileService(ContactSaver contactSaver, ContactLoader contactLoader)
        {
            _contactSaver = contactSaver;
            _contactLoader = contactLoader;
        }

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
