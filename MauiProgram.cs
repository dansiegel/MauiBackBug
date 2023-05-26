using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace MauiBackBug;

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
            })
            .ConfigureLifecycleEvents(lifecycle =>
#if ANDROID
                lifecycle.AddAndroid(android => android
                    .OnBackPressed(activity =>
                    {
                        Console.WriteLine("Android Lifecycle - OnBackPressed");
                        // This will fire after the GoBack from the Nav Page
                        System.Diagnostics.Debugger.Break();
                        if (App.Current.MainPage is NavigationPage nav && nav.Navigation.NavigationStack.Count == 1)
                        {
                            return false;
                        }

                        return true;
                    })
                )
#endif
            );


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
