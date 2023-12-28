namespace AddressBookConsole.Service.MenuService
{
    /// <summary>
    /// Manages the options chosen by the user.
    /// </summary>
    /// <param name="contactDisplayManager"></param>
    /// <param name="contactRegistrationManager"></param>
    /// <param name="contactRemovalManager"></param>
    public class OptionManager(
        ContactDisplayManager contactDisplayManager,
        ContactRegistrationManager contactRegistrationManager,
        ContactRemovalManager contactRemovalManager)
    {
        private readonly ContactDisplayManager _contactDisplayManager = contactDisplayManager;
        private readonly ContactRegistrationManager _contactRegistrationManager = contactRegistrationManager;
        private readonly ContactRemovalManager _contactRemovalManager = contactRemovalManager;

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
