using AddressBookMaui.Model;
using Newtonsoft.Json;

namespace AddressBookMaui.Service.FileService
{
    /// <summary>
    /// Loads contacts from a file.
    /// </summary>
    /// <param name="filePath"></param>
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
