namespace AddressBookConsole.Service.MenuService
{
    public class OptionManager
    {
        private readonly ContactService.ContactService _contactService;
        private readonly OptionHandler _optionHandler;

        public OptionManager(
            ContactService.ContactService contactService,
            ContactDisplayManager contactDisplayManager,
            ContactRegistrationManager contactRegistrationManager,
            ContactRemovalManager contactRemovalManager)
        {
            _contactService = contactService;
            _optionHandler = new OptionHandler(contactDisplayManager, contactRegistrationManager, contactRemovalManager);
        }

        public void HandleOption(string option)
        {
            _optionHandler.HandleOption(option);
        }
    }
}
