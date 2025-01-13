using AndroidX.ConstraintLayout.Core;
using Firebase.Analytics;
using mauinewfirebase.Googlesevices;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace mauinewfirebase
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
                }).ConfigureLifecycleEvents(events =>
                {
#if IOS
                events.AddiOS(iOS => iOS.FinishedLaunching((App, launchOptions) => {
                        Firebase.Core.App.Configure();
                        return false;   
                }));
#endif
#if ANDROID
                    events.AddAndroid(android => android.OnCreate((activity, bundle) =>
                    {
                        Firebase.FirebaseApp.InitializeApp(activity);
                    }));                    
#endif



                });
            builder.Services.AddSingleton<IAnalyticsService, AnalyticsService>();

#if DEBUG
            builder.Logging.AddDebug();
            builder.Services.AddSingleton<MainPage>();
#endif

            return builder.Build();
        }
    }
}
