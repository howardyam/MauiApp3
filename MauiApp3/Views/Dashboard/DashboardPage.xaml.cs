
using MauiApp3.ViewModels.Dashboard;
namespace MauiApp3.Views.Dashboard;

public partial class DashboardPage : ContentPage
{
    public DashboardPage(DashboardPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}