﻿using OnlineWallet.Context;
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

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);

            if (existingUser != null)
            {
                throw new InvalidOperationException("E-mail is already registered");
            }

            string? PasswordEncrypted = ! string.IsNullOrEmpty(newUser.Password)
                                        ? await _sercurityServices.EncryptPassword(newUser.Password)
                                        : null;

            var User = new User
            {
                Name = newUser.Name,
                Email = newUser.Email,
                PasswordHash = PasswordEncrypted
            };

            _context.Add(User);
            await _context.SaveChangesAsync();


            return User;
        }
    }
}
