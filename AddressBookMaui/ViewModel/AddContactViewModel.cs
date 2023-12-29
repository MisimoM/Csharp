using AddressBookConsole.Service.ContactService;
using AddressBookMaui.Messages;
using AddressBookMaui.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AddressBookMaui.ViewModel
{
    /// <summary>
    /// Resposible for adding new contacts.
    /// </summary>
    /// <param name="contactService"></param>
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

        /// <summary>
        /// Creates a new contact and adds it to the list.
        /// Sends a message to the MainViewModel to update the list.
        /// Navigates to the Main Page.
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task AddContact()
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
            await Shell.Current.GoToAsync("..");
        }
    }
}
