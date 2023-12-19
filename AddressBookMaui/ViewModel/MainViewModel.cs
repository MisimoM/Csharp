using AddressBookConsole.Service.ContactService;
using AddressBookMaui.Messages;
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

    }
}
