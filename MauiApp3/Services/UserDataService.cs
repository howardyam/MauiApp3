// UserDataService.cs in your Services directory
using SQLite;
using MauiApp3.Models;
using System.Threading.Tasks;

public class UserDataService
{
    private readonly SQLiteAsyncConnection _database;

    public UserDataService(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<UserBasicInfo>().Wait();
    }

    public Task<UserBasicInfo> GetUserByEmailAsync(string email)
    {
        // Implementation to retrieve a user by email from the database
        return _database.Table<UserBasicInfo>().Where(u => u.Email == email).FirstOrDefaultAsync();
    }

    public Task SaveUserAsync(UserBasicInfo user)
    {
        // Implementation to insert a new user into the database
        return _database.InsertAsync(user);
    }
}
