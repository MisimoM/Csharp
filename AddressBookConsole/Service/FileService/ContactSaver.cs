using AddressBookConsole.Model;
using Newtonsoft.Json;

namespace AddressBookConsole.Service.FileService
{
    // Saves contacts to a file.
    public class ContactSaver
    {
        private readonly string _filePath;

        public ContactSaver(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveContacts(List<ContactModel> contacts)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(_filePath);
                string json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
                writer.Write(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving contacts: {ex.Message}");
            }
        }
    }
}
