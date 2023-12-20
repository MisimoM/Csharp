using AddressBookConsole.Service.ContactService;
using AddressBookMaui.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AddressBookMaui.ViewModel
{
    public partial class BaseViewModel(ContactService contactService) : ObservableObject
    {

        private readonly ContactService _contactService = contactService;

        [ObservableProperty]
        private ObservableCollection<ContactModel> _contacts = [];

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
    }
}
