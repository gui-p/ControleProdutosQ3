using System.ComponentModel.DataAnnotations;

namespace ControleProdutosQ3.Controllers
{
    public class ValidaModels
    {

        public static bool Valida<Model>(Model model)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);
            bool resultado = Validator.TryValidateObject(model, context, results, true);
            return resultado;
        }

    }
}
