using AddressBookConsole.Service.FileService;
using AddressBookConsole.Service.ContactService;
using AddressBookConsole.Service.MenuService;

ContactLoader contactLoader = new("contactList.json");
ContactSaver contactSaver = new("contactList.json");

FileService fileService = new(contactSaver, contactLoader);
ContactService contactService = new(fileService);

ContactDisplayManager contactDisplayManager = new(contactService);
InputValidator inputValidator = new(contactService);
ContactRegistrationManager contactRegistrationManager = new(contactService, inputValidator);
ContactRemovalManager contactRemovalManager = new(contactService);

MenuService menuService = new(contactDisplayManager, contactRegistrationManager, contactRemovalManager);
menuService.ShowMainMenu();
