using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineWallet.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int WalletId { get; set; }
        [JsonIgnore]
        public Wallet? Wallet { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Descriptor { get; set; }
        public decimal Amount { get; set; }
        public string? Type { get; set; }
        public DateTime Date { get; set; }

        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((Type == null || Type == "Expense") ? "- " : "+ ") + Amount.ToString("C0");
            }
        }
    }
}
