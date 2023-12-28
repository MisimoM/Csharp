using AddressBookConsole.Model;

namespace AddressBookConsole.Interface
{
    public interface IFileService
    {
        List<ContactModel> LoadContacts();
        void SaveContacts(List<ContactModel> contacts);
    }
}
