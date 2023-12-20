using AddressBookConsole.Service.ContactService;
using AddressBookMaui.Messages;
using AddressBookMaui.Model;
using AddressBookMaui.View;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;


namespace AddressBookMaui.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        public MainViewModel(ContactService contactService) : base(contactService)
        {
            GetContactsToList();

            WeakReferenceMessenger.Default.Register<UpdatedListMessage>(this, (r, m) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    OnListUpdated(m.Value);
                });
            });
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
