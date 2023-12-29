using AddressBookConsole.Service.ContactService;
using AddressBookMaui.Messages;
using AddressBookMaui.Model;
using AddressBookMaui.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace AddressBookMaui.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ContactModel> _contacts = [];

        private readonly ContactService _contactService;

        public MainViewModel(ContactService contactService)
        {
            _contactService = contactService;
            
            GetContactsToList();

            // The message reciever to update the contact list.
            WeakReferenceMessenger.Default.Register<UpdatedListMessage>(this, (r, m) =>
            {
                UpdateList(m.Value);
            });
        }

        private void GetContactsToList()
        {
            try
            {
                var contacts = _contactService.GetContacts();
                
                Contacts.Clear();

                foreach (ContactModel contact in contacts)
                    Contacts.Add(contact);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get contacts: {ex.Message}");
            }
        }

        /// <summary>
        /// When message is recieved the list gets updated.
        /// </summary>
        /// <param name="message"></param>
        private void UpdateList(string message)
        {
            GetContactsToList();
        }

        /// <summary>
        /// // Navigates to the DetailsPage with data of the tapped contact.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [RelayCommand]
        private async Task GoToContactDetails(ContactModel contact)
        {
            if (contact is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", false,
                new Dictionary<string, object>
                {
                    {"Contact", contact }
                });
        }

        /// <summary>
        /// // Navigates to the AddContactPage.
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task GoToAddContactPage()
        {
            await Shell.Current.GoToAsync(nameof(AddContactPage));
        }
    }
}
