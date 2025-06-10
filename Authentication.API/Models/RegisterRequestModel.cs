using System.ComponentModel.DataAnnotations;

namespace Authentication.API.Models
{
    public class RegisterRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória!")]
        public required string Senha { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório!")]
        public required string Email { get; set; }

        public DateTime DataCadastro { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
