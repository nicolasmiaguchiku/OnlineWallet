using Microsoft.EntityFrameworkCore;
using OnlineWallet.Context;
using OnlineWallet.Interfaces;
using OnlineWallet.Models;
using OnlineWallet.ViewModels;


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

        public async Task<Transaction> AddOrEdit(TransactionViewModel newTransaction, int userId)
        {
            var wallet = await _dataContext.Wallets
                                  .FirstOrDefaultAsync(w => w.UserId == userId);

            if (wallet == null)
            {
                throw new InvalidOperationException("Carteira não encontrada para o usuário.");
            }
            else
            {
               Transaction transaction = new Transaction
               {
                    Title = newTransaction.Title!,
                    Amount = newTransaction.Amount,
                    Descriptor = newTransaction.Descriptor,
                    Type = newTransaction.Type.ToString(),
                    Date = (DateTime)newTransaction.Date!,
                    WalletId = wallet.WalletId
                };

                _dataContext.Transactions.Add(transaction);
                await _dataContext.SaveChangesAsync();

                return transaction;
            }
           
        }

    }
}
