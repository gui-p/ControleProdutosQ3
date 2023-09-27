using ControleProdutosQ3.Models;
using ControleProdutosQ3.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ControleProdutosQ3.Controllers
{
    public class ProdutoController : Controller
    {

        //Injeção de dependência
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            List<ProdutoModel> produtos = await _produtoRepositorio.BuscarTodos();
            return await Task.FromResult(View(produtos));
        }

        public async Task<IActionResult> Criar()
        {
            return await Task.FromResult(View());
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ProdutoModel produto)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(produto);
            bool isValid = Validator.TryValidateObject(produto, context, results, true);
            if (!isValid)
            {
                foreach (ValidationResult validationResult in results)
                {
                    return await Task.FromResult(View(produto));
                }
            }


            produto.DataDeRegistro = DateTime.Now;
            produto.Ativo = true;

            await _produtoRepositorio.Adicionar(produto);

            return await Task.FromResult(RedirectToAction("Index"));
        }
    }
}
