using Microsoft.AspNetCore.Mvc;
using OnlineWallet.Interfaces;
using OnlineWallet.Services;
using OnlineWallet.ViewModels;
using System.Security.Claims;
using System.Transactions;

namespace OnlineWallet.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionServices _transactionServices;

        public TransactionsController(ITransactionServices transactionServices)
        {
            _transactionServices = transactionServices ?? throw new ArgumentNullException(nameof(transactionServices));
        }

        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var userId = int.Parse(userIdClaim!);

            var transactions = await _transactionServices.GetTransactionsByUser(userId);

            return View(transactions);
        }

        public IActionResult AddOrEdit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTransaction(TransactionViewModel transaction)
        {
            if (ModelState.IsValid)
            {

                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("Usuário não autenticado.");
                }

                var newTransaction = await _transactionServices.AddTransaction(transaction, int.Parse(userId));
                return RedirectToAction("Index");
            }

            return View(transaction);
        }
    }
}
