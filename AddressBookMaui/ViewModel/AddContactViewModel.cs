using AddressBookConsole.Service.ContactService;
using AddressBookMaui.Messages;
using AddressBookMaui.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AddressBookMaui.ViewModel
{
    public partial class AddContactViewModel(ContactService contactService) : ObservableObject
    {
        private readonly ContactService _contactService = contactService;

        [ObservableProperty]
        string _firstName = string.Empty;

        [ObservableProperty]
        string _lastName = string.Empty;

        [ObservableProperty]
        string _email = string.Empty;

        [ObservableProperty]
        string _phoneNumber = string.Empty;

        [ObservableProperty]
        string _streetName = string.Empty;

        [ObservableProperty]
        string _postalCode = string.Empty;

        [ObservableProperty]
        string _city = string.Empty;


        [RelayCommand]
        private void AddContact()
        {
            ContactModel contact = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                StreetName = StreetName,
                PostalCode = PostalCode,
                City = City
            };

            _contactService.AddContact(contact);
            WeakReferenceMessenger.Default.Send(new UpdatedListMessage("Contacts Updated"));

            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            StreetName = string.Empty;
            PostalCode = string.Empty;
            City = string.Empty;
        }
    }
}
