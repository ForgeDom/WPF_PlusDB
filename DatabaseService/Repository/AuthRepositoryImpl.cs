using Core.Repository.AuthRepository;
using DatabaseService.DBProvider;
using DatabaseService.Models;

namespace DatabaseService.Repository;

public class AuthRepositoryImpl(DatabaseProvider databaseProvider) : AuthRepository
{
    [Obsolete("Obsolete")]
    public override async Task<bool> RegisterAsync(string email, string password)
    {
        UserModel user = new UserModel(0, email, password);
        var resultResponse = await databaseProvider.CreateUserAsync(user);
        return resultResponse > 0;
    }       
    
    [Obsolete("Obsolete")]
    public override async Task<bool> LoginAsync(string email, string password)
    {
        var user = await databaseProvider.GetUserAsync(email);
        if (user != null && user.password == password)
            return true;
        return false;
    }
}
