namespace AddressBookConsole.Service.MenuService
{
    /// <summary>
    /// Service responsible for managing the main menu.
    /// </summary>
    /// <param name="contactDisplayManager"></param>
    /// <param name="contactRegistrationManager"></param>
    /// <param name="contactRemovalManager"></param>
    public class MenuService(
        ContactDisplayManager contactDisplayManager,
        ContactRegistrationManager contactRegistrationManager,
        ContactRemovalManager contactRemovalManager)
    {
        private readonly OptionManager _optionManager = new(contactDisplayManager, contactRegistrationManager, contactRemovalManager);

        public void ShowMainMenu()
        {
            while (true)
            {
                //Gets the option from the user.
                string option = MainMenuDisplay.GetOption();

                //Handles the option from the user.
                _optionManager.HandleOption(option);

                Console.ReadKey();
            }
        }
    }
}
