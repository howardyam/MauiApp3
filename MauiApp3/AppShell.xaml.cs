using MauiApp3.Models;
using MauiApp3.ViewModels;
using MauiApp3.Views.Dashboard;
using MauiApp3.Views.Startup;

namespace MauiApp3;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        this.BindingContext = new AppShellViewModel();
        Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));



    }
}
