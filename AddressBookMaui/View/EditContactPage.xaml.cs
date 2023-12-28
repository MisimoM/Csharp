using AddressBookMaui.ViewModel;

namespace AddressBookMaui.View;

public partial class EditContactPage : ContentPage
{
	public EditContactPage(EditContactViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}