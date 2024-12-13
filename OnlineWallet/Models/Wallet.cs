using System.ComponentModel.DataAnnotations;

namespace OnlineWallet.Models
{
    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
        public double Investment { get; set; }
    }
}
