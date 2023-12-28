using AddressBookConsole.Service.FileService;
using AddressBookConsole.Service.ContactService;
using AddressBookConsole.Service.MenuService;

string filePath = "C:\\Users\\Marko\\Desktop\\Projects\\Education\\C#\\AddressBookConsole\\AddressBookConsole\\ContactList.json";

ContactLoader contactLoader = new(filePath);
ContactSaver contactSaver = new(filePath);

FileService fileService = new(contactSaver, contactLoader);
ContactService contactService = new(fileService);

ContactDisplayManager contactDisplayManager = new(contactService);
InputValidator inputValidator = new(contactService);
ContactRegistrationManager contactRegistrationManager = new(contactService, inputValidator);
ContactRemovalManager contactRemovalManager = new(contactService);

MenuService menuService = new(contactDisplayManager, contactRegistrationManager, contactRemovalManager);
menuService.ShowMainMenu();
