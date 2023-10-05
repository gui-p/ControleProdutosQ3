using System.ComponentModel.DataAnnotations;

namespace ControleProdutosQ3.Models
{
    public class EnderecoModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Precisa conter 9 digitos")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Somente caracteres numéricos")]
        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public long? ClienteId { get; set; }

        public ClienteModel? Cliente { get; set; }

    }
}
