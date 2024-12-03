using HospedaFacil.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospedaFacil.Application.DTOs
{
    public class RegistraUsuarioDTO
    {
        public string Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        [Compare("Senha")]
        public string ConfirmarSenha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public TipoUsuario TpUsuario { get; set; }
        public DateTime DataCriacaoConta { get; set; }
    }
}
