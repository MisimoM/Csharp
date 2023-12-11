using AddressBookConsole.Model;
using Newtonsoft.Json;

namespace AddressBookConsole.Service.FileService
{
    // Loads contacts from a file.
    public class ContactLoader(string filePath)
    {
        private readonly string _filePath = filePath;

        public List<ContactModel> LoadContacts()
        {
            List<ContactModel> contacts = [];

            try
            {
                if (File.Exists(_filePath))
                {
                    using StreamReader reader = new(_filePath);
                    string json = reader.ReadToEnd();
                    contacts = JsonConvert.DeserializeObject<List<ContactModel>>(json)!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading contacts: {ex.Message}");
            }

            return contacts;
        }
    }
}
