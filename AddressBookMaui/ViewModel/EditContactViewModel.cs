using AddressBookConsole.Service.ContactService;
using AddressBookMaui.Messages;
using AddressBookMaui.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AddressBookMaui.ViewModel
{
    /// <summary>
    /// Responsible for editing contacts.
    /// </summary>
    [QueryProperty(nameof(Contact), "Contact")]
    public partial class EditContactViewModel : ObservableObject
    {
        private readonly ContactService _contactService;

        public EditContactViewModel(ContactService contactService)
        {
            _contactService = contactService;
            Contact = null!;
        }

        [ObservableProperty]
        ContactModel _contact;
        
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
        /// Edits the contact and saves it to the list.
        /// Sends a message to the MainViewModel to update the list.
        /// Navigates back to the HomePage.
        /// </summary>
        /// <param name="Contact"></param>
        /// <returns></returns>
        [RelayCommand]
        private async Task SaveEditedContact(ContactModel Contact)
        {
            ContactModel editedContact = new()
            {
                Id = Contact.Id,
                FirstName = Contact.FirstName,
                LastName = Contact.LastName,
                Email = Contact.Email,
                PhoneNumber = Contact.PhoneNumber,
                StreetName = Contact.StreetName,
                PostalCode = Contact.PostalCode,
                City = Contact.City
            };

            _contactService.EditContact(Contact, editedContact);
            WeakReferenceMessenger.Default.Send(new UpdatedListMessage("Contacts Updated"));
            
            await Shell.Current.GoToAsync("../..");

        }
    }
}
