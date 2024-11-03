using OnlineWallet.Interfaces;

namespace OnlineWallet.Services
{
    public class SecuritySevices : ISecurityServices
    {
        public Task<bool> ComparePassword(string password, string confirmPassword)
        {
            bool isEqual = password.Trim().Equals(confirmPassword.Trim());

            return Task.FromResult(isEqual);
        }

        public Task<string> EncryptPassword(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            return Task.FromResult(passwordHash);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
