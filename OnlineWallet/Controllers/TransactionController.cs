using Microsoft.AspNetCore.Mvc;
using OnlineWallet.Interfaces;
using OnlineWallet.Services;
using System.Security.Claims;

namespace OnlineWallet.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionServices _transactionServices;

        public TransactionController(ITransactionServices transactionServices)
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
    }
}
