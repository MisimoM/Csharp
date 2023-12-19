using AddressBookMaui.ViewModel;

namespace AddressBookMaui.View;

public partial class AddContactPage : ContentPage
{

    public AddContactPage(AddContactViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}