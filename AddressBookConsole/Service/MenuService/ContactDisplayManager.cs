﻿namespace AddressBookConsole.Service.MenuService
{
    public class ContactDisplayManager
    {
        private readonly ContactService.ContactService _contactService;

        public ContactDisplayManager(ContactService.ContactService contactService)
        {
            _contactService = contactService;
        }

        public void ShowContacts()
        {
            Console.Clear();
            Console.WriteLine("Contact list");
            Console.WriteLine();
            foreach (var contact in _contactService.GetContacts())
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Phone: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Address: {contact.StreetName}, {contact.PostalCode}, {contact.City}");
                Console.WriteLine();
            }
        }
    }
}