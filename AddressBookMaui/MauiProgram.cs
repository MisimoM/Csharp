using AddressBookConsole.Service.ContactService;
using AddressBookMaui.Service.FileService;
using AddressBookMaui.ViewModel;
using AddressBookMaui.View;
using Microsoft.Extensions.Logging;

namespace AddressBookMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            var filePath = "C:\\Users\\Marko\\Desktop\\Projects\\Education\\C#\\AddressBookConsole\\AddressBookMaui\\ContactList.json";
            builder.Services.AddSingleton(new ContactService(new FileService(new ContactSaver(filePath), new ContactLoader(filePath))));

            builder.Services.AddTransient<AddContactPage>();
            builder.Services.AddTransient<AddContactViewModel>();

            builder.Services.AddTransient<DetailsPage>();
            builder.Services.AddTransient<DetailsViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
