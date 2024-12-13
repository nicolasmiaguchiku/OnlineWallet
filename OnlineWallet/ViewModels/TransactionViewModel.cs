using System.ComponentModel.DataAnnotations;

namespace OnlineWallet.ViewModels
{
    public enum TransactionType
    {
        Expense,
        Income,
        Investiment
    }
    public class TransactionViewModel
    {
        [Required(ErrorMessage = "Titulo da transação obrigatório.")]
        public string? Title { get; set; }

        public DateTime Date = DateTime.Now;

        [Range(0.01, double.MaxValue, ErrorMessage = "O valor da transação deve ser maior que 0.")]
        public double Amount { get; set; }

        public TransactionType Type { get; set; }
    }
}
