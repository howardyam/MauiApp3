using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using MauiApp3.Controls;
using MauiApp3.Models;
using MauiApp3.Views.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiApp3.Views; // Adjust MyAppNamespace to the namespace where SignUpPage is located
using MauiApp3.Views.Startup;

namespace MauiApp3.ViewModels.Startup
{
    public partial class LoginPageViewModel : BaseViewModel
    {

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;
        public ICommand NavigateToSignUpCommand { get; }

        public LoginPageViewModel()
        {
            NavigateToSignUpCommand = new RelayCommand(NavigateToSignUp);
        }

        #region Commands
        [ICommand]
        async void Login()
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                var userDetails = new UserBasicInfo();
                userDetails.Email = Email;
                userDetails.FullName = "Test User Name";

                // These below are just for testing, don't really use it if you don't want to die.
                // Student Role, Teacher Role, Admin Role,
                if (Email.ToLower().Contains("student"))
                {
                    userDetails.RoleID = (int)RoleDetails.Student;
                    userDetails.RoleText = "Student Role";
                }
                else if (Email.ToLower().Contains("teacher"))
                {
                    userDetails.RoleID = (int)RoleDetails.Teacher;
                    userDetails.RoleText = "Teacher Role";
                }
                else
                {
                    userDetails.RoleID = (int)RoleDetails.Admin;
                    userDetails.RoleText = "Admin Role";
                }


                // calling api 


                if (Preferences.ContainsKey(nameof(App.UserDetails)))
                {
                    Preferences.Remove(nameof(App.UserDetails));
                }

                string userDetailStr = JsonConvert.SerializeObject(userDetails);
                Preferences.Set(nameof(App.UserDetails), userDetailStr);
                App.UserDetails = userDetails;
                await AppConstant.AddFlyoutMenusDetails();
            }


        }
        private async void NavigateToSignUp()
        {
            // Navigate to the SignUpPage
            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }
        #endregion
    }
}