using OnlineWallet.Context;
using OnlineWallet.Interfaces;
using OnlineWallet.Models;
using OnlineWallet.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace OnlineWallet.Services
{
    public class UserServices : IUserServices
    {
        private readonly SecuritySevices _sercurityServices;
        private readonly DataContext _context;


        public UserServices(SecuritySevices securityServices, DataContext context)
        {
            _sercurityServices = securityServices;
            _context = context;
        }

        public async Task<User> Register(RegisterViewModel newUser)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var existingUser = await _context.Users
                                   .Where(u => u.Email == newUser.Email)
                                   .AnyAsync()
                                   .ConfigureAwait(false);

                if (existingUser)
                {
                    throw new InvalidOperationException("E-mail is already registered");
                }

                var passwordEncryptedTask = _sercurityServices.EncryptPassword(newUser.Password);

                string? passwordEncrypted = await passwordEncryptedTask;


                var user = new User
                {
                    Name = newUser.Name,
                    Email = newUser.Email,
                    PasswordHash = passwordEncrypted
                };

                var wallet = new Wallet
                {
                    UserId = user.UserId,
                    Investment = 0
                };


                _context.Users.Add(user);
                _context.Wallets.Add(wallet);

                await _context.SaveChangesAsync().ConfigureAwait(false);

                user.Wallet = wallet;

                await transaction.CommitAsync();

                return user;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task<User?> AuthenticateUser(string email, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);

            if (user == null || string.IsNullOrEmpty(user.PasswordHash) || !_sercurityServices.VerifyPassword(password, user.PasswordHash))
            {
                throw new InvalidOperationException("Incorrect email or password");
            }

            return user;

        }

    }
}
