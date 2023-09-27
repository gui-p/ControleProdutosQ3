using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ControleProdutosQ3.Models
{
    [Index(nameof(CodigoDeBarras), IsUnique = true)]
    public class ProdutoModel
    {
        [Required]
        public long Id { get; set; }

        [StringLength(12, MinimumLength=12, ErrorMessage = "Precisa de 12 caracteres!")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "O campo aceita apenas números")]
        public string CodigoDeBarras { get; set; }


        //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]       
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set;}


        //[Range(typeof(DateTime), minimum: "23/09/2023", maximum:"24/09/2024")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataDeValidade { get; set; }    

        [DataType(DataType.DateTime)]
        public DateTime DataDeRegistro { get; set; }


        [Range(1,1000)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Quantidade {  get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName  = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [MaybeNull] public string? NomeDaFoto { get; set; }

        [MaybeNull] public byte[]? Foto {  get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public bool Ativo {  get; set; }

    }
}
