﻿namespace AddressBookMaui.Model
{
    /// <summary>
    /// Model for the contact.
    /// </summary>
    public class ContactModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public string FullName => $"{FirstName} {LastName}";
        public string Address => $"{StreetName}, {PostalCode}, {City}";
    }
}
