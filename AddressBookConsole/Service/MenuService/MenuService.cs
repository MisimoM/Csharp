namespace AddressBookConsole.Service.MenuService
{
    // Main menu service facilitates user interaction.
    public class MenuService
    {
        private readonly OptionManager _optionManager;

        public MenuService(
            ContactService.ContactService contactService,
            ContactDisplayManager contactDisplayManager,
            ContactRegistrationManager contactRegistrationManager,
            ContactRemovalManager contactRemovalManager)
        {
            _optionManager = new OptionManager(contactService, contactDisplayManager, contactRegistrationManager, contactRemovalManager);
        }

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
