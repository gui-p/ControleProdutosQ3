using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ControleProdutosQ3.Models
{
    public class ClienteModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public long Id {  get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Deve conter entre 10 e 11 digitos com DDD")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Somente caracteres numéricos com DDD")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(8, ErrorMessage = "Precisa conter 8 digitos")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Somente caracteres numéricos")]
        public string CEP { get; set; }

        [MaybeNull] public string? NomeDaFoto { get; set; }

        [MaybeNull]
        public byte[]? Foto { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public bool Ativo { get; set; } 
        

    }
}
