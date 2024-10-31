using System.ComponentModel.DataAnnotations;


namespace OnlineWallet.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
