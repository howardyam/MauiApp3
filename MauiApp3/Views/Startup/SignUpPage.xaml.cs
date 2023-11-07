// SignUpPage.xaml.cs
using MauiApp3.ViewModels.Startup;
using Microsoft.Maui.Controls;
using System;

namespace MauiApp3.Views.Startup
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage(SignUpPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
