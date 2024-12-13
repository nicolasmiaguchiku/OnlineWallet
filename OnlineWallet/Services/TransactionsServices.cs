using Microsoft.EntityFrameworkCore;
using OnlineWallet.Context;
using OnlineWallet.Interfaces;
using OnlineWallet.Models;

namespace OnlineWallet.Services
{
    public class TransactionsServices : ITransactionServices
    {
        private readonly DataContext _dataContext;


        public TransactionsServices(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<List<Transaction>> GetTransactionsByUser(int userId)
        {
            var wallet = await _dataContext.Wallets
                                           .Include(w => w.Transactions)
                                           .FirstOrDefaultAsync(w => w.UserId == userId);

            if(wallet == null)
            {
                throw new InvalidOperationException("Carteira não encontrada para o usuário.");
            }

            return wallet.Transactions?.ToList() ?? new List<Transaction>();

        }

    }
}
