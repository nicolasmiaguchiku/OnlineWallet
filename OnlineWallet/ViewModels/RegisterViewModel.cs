using System.ComponentModel.DataAnnotations;

namespace OnlineWallet.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O nome do usúario é obrigatório.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O formato de e-mail é inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public string? ConfirmPassword { get; set; }    

    }
}
