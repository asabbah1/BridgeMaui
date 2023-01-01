using Bridge.Services;
using Bridge.ViewModels;
using Bridge.Views;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;
using Acr.UserDialogs;
using Microsoft.Maui.Handlers;

#if ANDROID
[assembly: Android.App.UsesPermission(Android.Manifest.Permission.Camera)]
#endif

namespace Bridge;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();


#pragma warning disable CA1416 // Validate platform compatibility
        builder
            .UseMauiApp<App>()
            .RegisterAppServices()
            .RegisterViewModels()
            .RegisterViews()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
            .UseBarcodeReader()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemiBold");
                fonts.AddFont("fa-regular-400.ttf", "FaRegular");
            });
#pragma warning restore CA1416 // Validate platform compatibility

        builder.Services.AddLocalization();


#if __ANDROID__
        ImageHandler.Mapper.PrependToMapping(nameof(Microsoft.Maui.IImage.Source), (handler, view) => PrependToMappingImageSource(handler, view));
#endif

        return builder.Build();
    }

#if __ANDROID__
    public static void PrependToMappingImageSource(IImageHandler handler, Microsoft.Maui.IImage image)
    {
        handler.PlatformView?.Clear();
    }
#endif

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton(typeof(IFingerprint), CrossFingerprint.Current);
        mauiAppBuilder.Services.AddSingleton<IAccountService, AccountService>();
        mauiAppBuilder.Services.AddSingleton<IAlertService, AlertService>();
        mauiAppBuilder.Services.AddSingleton<IBarcodeService, BarcodeService>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<OnboardingViewModel>();
        mauiAppBuilder.Services.AddTransient<LoginViewModel>();
        mauiAppBuilder.Services.AddTransient<HomeViewModel>();
        mauiAppBuilder.Services.AddTransient<TransactionsViewModel>();
        mauiAppBuilder.Services.AddTransient<ProfileViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<OnboardingView>();
        mauiAppBuilder.Services.AddTransient<LoginView>();
        mauiAppBuilder.Services.AddTransient<HomeView>();
        mauiAppBuilder.Services.AddTransient<TransactionsView>();
        mauiAppBuilder.Services.AddTransient<ProfileView>();

        return mauiAppBuilder;
    }
}
