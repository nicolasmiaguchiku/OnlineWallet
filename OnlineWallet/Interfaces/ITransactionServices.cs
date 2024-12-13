using OnlineWallet.Models;

namespace OnlineWallet.Interfaces
{
    public interface ITransactionServices
    {
        Task<List<Transaction>> GetTransactionsByUser(int userId);
    }
}
