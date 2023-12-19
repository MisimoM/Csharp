using AddressBookMaui.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AddressBookMaui.ViewModel
{
    [QueryProperty(nameof(Contact), "Contact")]
    public partial class DetailsViewModel : ObservableObject
    {
        public DetailsViewModel()
        {
            
        }

        [ObservableProperty]
        ContactModel contact;

    }
}
