namespace OnlineWallet.Interfaces
{
    public interface ISecurityServices
    {
        public Task<bool> ComparePassword(string password, string confirmPassword);
        public Task<string> EncryptPassword(string password);
        public bool VerifyPassword(string password, string passwordHash);
    }
}