namespace AddressBookConsole.Service.MenuService
{
    /// <summary>
    /// Displays the main menu.
    /// </summary>
    public class MainMenuDisplay
    {
        public static string GetOption()
        {
            Console.Clear();
            Console.WriteLine("Address Book");
            Console.WriteLine();
            Console.WriteLine("1. Show Contacts");
            Console.WriteLine("2. Add Contact");
            Console.WriteLine("3. Remove Contact");
            Console.WriteLine("0. Exit Address Book");
            Console.WriteLine();
            Console.Write("Choose an option: ");
            return Console.ReadLine() ?? "";
        }
    }
}
