using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ControleProdutosQ3.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class LoginModel
    {
        public long Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Senha { get; set; }

		[MaybeNull]
		public string Telefone { get; set; } 

        public int NivelAcesso { get; set; }

        public bool Ativo { get; set; }

        public bool? EmailConfirmado { get; set; }

        
        public bool? TelefoneConfirmado { get; set; }

        public DateTime DataRegistro { get; set; }

    }
}
