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
}
