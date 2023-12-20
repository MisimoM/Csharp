﻿using AddressBookMaui.Model;
using Newtonsoft.Json;

namespace AddressBookMaui.Service.FileService
{
    // Saves contacts to a file.
    public class ContactSaver(string filePath)
    {
        private readonly string _filePath = filePath;

        public void SaveContacts(List<ContactModel> contacts)
        {
            try
            {
                using StreamWriter writer = new(_filePath);
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