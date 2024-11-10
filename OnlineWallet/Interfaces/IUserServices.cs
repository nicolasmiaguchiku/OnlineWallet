using OnlineWallet.Models;
using OnlineWallet.ViewModels;

namespace OnlineWallet.Interfaces
{
    public interface IUserServices
    {
        Task<User> Register(RegisterViewModel newUser);
        Task<User?> AuthenticateUser(string email, string passoword);
    }
}
