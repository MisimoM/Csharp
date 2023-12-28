using AddressBookConsole.Service.ContactService;
using AddressBookMaui.Messages;
using AddressBookMaui.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AddressBookMaui.ViewModel
{
    [QueryProperty(nameof(Contact), "Contact")]
    public partial class EditContactViewModel : ObservableObject
    {
        private readonly ContactService _contactService;

        public EditContactViewModel(ContactService contactService)
        {
            _contactService = contactService;
            Contact = _contactService.GetContactById(ContactId);
        }

        [ObservableProperty]
        ContactModel _contact;

        [ObservableProperty]
        private Guid _contactId;

        [RelayCommand]
        private async Task SaveEditedContact()
        {
            _contactService.EditContact();
            WeakReferenceMessenger.Default.Send(new UpdatedListMessage("Contacts Updated"));
            await Shell.Current.GoToAsync("../..");
        }
    }
}
