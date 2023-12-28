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

            WeakReferenceMessenger.Default.Register<UpdatedListMessage>(this, (r, m) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    OnListUpdated(m.Value);
                });
            });
        }

        private protected void GetContactsToList()
        {

            try
            {
                var contacts = _contactService.GetContacts();
                    Contacts.Clear();

                foreach (var contact in contacts)
                    Contacts.Add(contact);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get contacts: {ex.Message}");
            }
        }

        private protected void OnListUpdated(string message)
        {
            GetContactsToList();
        }

        [RelayCommand]
        private async Task GoToContactDetails(ContactModel contact)
        {
            if (contact is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
                new Dictionary<string, object>
                {
                    {"Contact", contact }
                });
        }
    }
}
