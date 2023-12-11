namespace AddressBookConsole.Service.MenuService
{
    // Main menu service facilitates user interaction.
    public class MenuService(
        ContactDisplayManager contactDisplayManager,
        ContactRegistrationManager contactRegistrationManager,
        ContactRemovalManager contactRemovalManager)
    {
        private readonly OptionManager _optionManager = new(contactDisplayManager, contactRegistrationManager, contactRemovalManager);

        // Displays the main menu and handeles user input.
        public void ShowMainMenu()
        {
            while (true)
            {
                // Gets the user's option
                string option = MainMenuDisplay.GetOption();

                // Handles the user's option using the option manager.
                _optionManager.HandleOption(option);

                Console.ReadKey();
            }
        }
    }
}
