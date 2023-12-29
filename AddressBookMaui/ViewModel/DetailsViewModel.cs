using AddressBookConsole.Service.ContactService;
using AddressBookMaui.Messages;
using AddressBookMaui.Model;
using AddressBookMaui.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AddressBookMaui.ViewModel
{
    /// <summary>
    /// Displays the contact details
    /// </summary>
    /// 
    [QueryProperty(nameof(Contact), "Contact")]
    public partial class DetailsViewModel : ObservableObject
    {
        private readonly ContactService _contactService;
        public DetailsViewModel(ContactService contactService) 
        {
            _contactService = contactService;
            Contact = null!;
        }

        [ObservableProperty]
        ContactModel _contact;

        // Navigates to EditContactPage to edit the contact.
        [RelayCommand]
        private async Task GoToEditContactPage(ContactModel contact)
        {

            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}", true,
                new Dictionary<string, object>
                {
                    {"Contact", contact }
                });
        }

        /// <summary>
        /// Removes the contact from the list.
        /// Send a message to the MainViewModel to update the list.
        /// Navigates back to the MainPage.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [RelayCommand]
        private async Task RemoveContactFromList(ContactModel contact)
        {
            _contactService.RemoveContact(contact);
            WeakReferenceMessenger.Default.Send(new UpdatedListMessage("Contacts Updated"));
            await Shell.Current.GoToAsync("..");
        }
    }
}
