using OnlineWallet.Models;
using OnlineWallet.ViewModels;

namespace OnlineWallet.Interfaces
{
    public interface IUserServices
    {
        Task<User> Register(RegisterViewModel newUser);
        
    }
}
