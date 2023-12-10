namespace AddressBookConsole.Service.MenuService
{
    public class OptionHandler
    {
        private readonly ContactDisplayManager _contactDisplayManager;
        private readonly ContactRegistrationManager _contactRegistrationManager;
        private readonly ContactRemovalManager _contactRemovalManager;

        public OptionHandler(
            ContactDisplayManager contactDisplayManager,
            ContactRegistrationManager contactRegistrationManager,
            ContactRemovalManager contactRemovalManager)
        {
            _contactDisplayManager = contactDisplayManager;
            _contactRegistrationManager = contactRegistrationManager;
            _contactRemovalManager = contactRemovalManager;
        }

        // Handles the option selected by the user.
        public void HandleOption(string option)
        {
            switch (option)
            {
                case "1":
                    _contactDisplayManager.ShowContacts();
                    break;
                case "2":
                    _contactRegistrationManager.AddContact();
                    break;
                case "3":
                    _contactDisplayManager.ShowContacts();
                    _contactRemovalManager.RemoveContact();
                    break;
                case "0":
                    Console.Clear();
                    Console.WriteLine("Closing the Address Book. Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }
    }
}
