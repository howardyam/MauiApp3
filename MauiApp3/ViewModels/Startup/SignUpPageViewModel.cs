using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MauiApp3.Models;
using MauiApp3.Views;

namespace MauiApp3.ViewModels.Startup
{
    public partial class SignUpPageViewModel : ObservableObject
    {
        private readonly UserDataService _userDataService;

        public SignUpPageViewModel()
        {
            // Get the path to the local application data directory.
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Create a path for the 'database' folder within the local application data directory.
            string databaseFolderPath = Path.Combine(folderPath, "database");

            // Ensure the 'database' folder exists.
            if (!Directory.Exists(databaseFolderPath))
            {
                Directory.CreateDirectory(databaseFolderPath);
            }

            // Create the path for the SQLite database file within the 'database' folder.
            string dbPath = Path.Combine(databaseFolderPath, "your_database_name.db");

            // Pass the database path to the UserDataService.
            _userDataService = new UserDataService(dbPath);
        }



        [ObservableProperty]
        private string fullName;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private int selectedRole;

        [ICommand]
        public async void SignUp()
        {
            // Perform validation (check for empty fields, password strength, etc.)
            var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.StorageWrite>();

                if (status != PermissionStatus.Granted)
                {
                    // Permission denied by the user
                    // Handle accordingly (e.g., show a message to the user)
                    return;
                }
            }
            // Check if user already exists
            var existingUser = await _userDataService.GetUserByEmailAsync(Email);
            if (existingUser != null)
            {
                // Inform the user that the email is already in use.
                return;
            }

            // Hash the password
            // Assuming PasswordHasher is a static class that you have created for hashing
            

            // Create the user object
            var user = new UserBasicInfo
            {
                FullName = FullName,
                Email = Email,
                Password = Password, // Store the hashed password
                RoleID = SelectedRole
            };

            // Save the user in the database
            await _userDataService.SaveUserAsync(user);

            // Option 1: Navigate to the login page
            await Shell.Current.GoToAsync("//LoginPage");

            // Option 2: Automatically log the user in and navigate to the dashboard
            // App.UserDetails = user;
            // await Shell.Current.GoToAsync("//DashboardPage"); // Replace with your actual dashboard page route
        }
    }
}
