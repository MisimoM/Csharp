using AddressBookMaui.Model;
using AddressBookMaui.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AddressBookMaui.ViewModel
{
    [QueryProperty(nameof(Contact), "Contact")]
    public partial class DetailsViewModel : ObservableObject
    {
        public DetailsViewModel() 
        {
            Contact = null!;
        }

        [ObservableProperty]
        ContactModel _contact;


        [RelayCommand]
        private async Task GoToEditContactPage(ContactModel contact)
        {

            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}", true,
                new Dictionary<string, object>
                {
                    {"Contact", contact }
                });
        }
    }
}
