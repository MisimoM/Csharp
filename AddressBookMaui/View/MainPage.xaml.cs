using AddressBookMaui.Model;
using AddressBookMaui.ViewModel;

namespace AddressBookMaui.View;

public partial class MainPage : ContentPage
{

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

    }

    private async void AddContactPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (((VisualElement)sender).BindingContext is ContactModel contact)
        {
            await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
            {
                {"Contact", contact}
            });
        }
    }
}
