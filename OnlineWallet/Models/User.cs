namespace OnlineWallet.Models
{
    public class User
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public string Name = string.Empty;
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }

    }
}
