using Bridge.Services;

namespace Bridge;

public partial class App : Application
{
    public static IServiceProvider Services;
    public static IAlertService AlertSvc;

    public App(IServiceProvider provider)
    {
        InitializeComponent();

        Services = provider;
        AlertSvc = Services.GetService<IAlertService>();

        int theme = Preferences.Get("theme", (int)App.Current.PlatformAppTheme);
        Application.Current.UserAppTheme = (AppTheme)theme;

        string lang = StorageHelper.GetLang();

        if (lang == "ar")
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ar-JO");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-JO");
            Globals.IsEnglish = false;
        }
        else
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            Globals.IsEnglish = true;
        }

        MainPage = new AppShell();

    }
}
