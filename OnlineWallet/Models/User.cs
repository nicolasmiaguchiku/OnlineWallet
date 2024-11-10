﻿using System.ComponentModel.DataAnnotations;

namespace OnlineWallet.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public Wallet? Wallet { get; set; }

    }
}
