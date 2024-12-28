using Microsoft.AspNetCore.Mvc;
using OnlineWallet.Models;
using OnlineWallet.ViewModels;

namespace OnlineWallet.Interfaces
{
    public interface ITransactionServices
    {
        Task<List<Transaction>> GetTransactionsByUser(int userId);

        Task<Transaction> AddTransaction(TransactionViewModel Transaction, int userId);
    }
}
