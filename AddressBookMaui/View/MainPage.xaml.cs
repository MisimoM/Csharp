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

    private async void GoToAddContactPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private async void GoToDetailsPage(object sender, EventArgs e)
    {
        if (((VisualElement)sender).BindingContext is not ContactModel contact)
            return;

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
            new Dictionary<string, object>
            {
                {"Contact", contact }
            });
    }


}
