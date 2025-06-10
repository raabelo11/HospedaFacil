using System.ComponentModel.DataAnnotations;

namespace Authentication.API.Models
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "E-mail é obrigatório!")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória!")]
        public required string Senha { get; set; }
    }
}
