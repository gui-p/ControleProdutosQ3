using ControleProdutosQ3.Models;
using ControleProdutosQ3.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ControleProdutosQ3.Controllers
{

    [ApiController]
    [Route("api/Produto")]
    public class ProdutoApiController : ControllerBase
    {

        //Injeção de dependência
        private readonly IProdutoRepositorio _produtoRepositorio;

        private readonly IWebHostEnvironment _environment;

        public ProdutoApiController(IProdutoRepositorio produtoRepositorio, IWebHostEnvironment environment)
        {
            _produtoRepositorio = produtoRepositorio;
            _environment = environment;
        }

        [HttpGet]
        //[EnableCors("Politica")]
        public async Task<IEnumerable<ProdutoModel>> ListarProdutos()
        {
            List<ProdutoModel> produtos = await _produtoRepositorio.BuscarTodos();
            return await Task.FromResult(produtos.ToArray());
        }

        [HttpGet("{id}")]
        public async Task<ProdutoModel> ObterProdutoPorId(long id)
        {
            ProdutoModel produto = await _produtoRepositorio.BuscarPorId(id);
            return await Task.FromResult(produto);
        }

        //public async Task<IActionResult> Editar(long id)
        //{
        //    ProdutoModel produto = await _produtoRepositorio.BuscarPorId(id);   
        //    return await Task.FromResult(View(produto));
        //}

        //[HttpPost]
        //public async Task<IActionResult> Alterar(ProdutoModel produto, IFormFile? imagemCarregada, DateTime dataAlterada)
        //{


        //    bool isValid = ValidaModels.Valida(produto);
        //    if (!isValid)
        //    {

        //        return await Task.FromResult(RedirectToAction("Editar", produto));

        //    }

        //    if (imagemCarregada != null)
        //    {
        //        produto.Foto = Util.SalvaImagem(imagemCarregada, _environment.WebRootPath);
        //        produto.NomeDaFoto = Path.GetFileName(imagemCarregada!.FileName);
        //    }
        //    else
        //    {
        //        produto.Foto = null;
        //        produto.NomeDaFoto = "";
        //    }


        //    produto.DataDeValidade = dataAlterada;

        //    await _produtoRepositorio.Atualizar(produto);
        //    return await Task.FromResult(RedirectToAction("Index"));
        //}

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> CadastraProduto(ProdutoModel produto)
        {
            produto.DataDeRegistro = DateTime.Now;
            produto.Ativo = true;

            try
            {
                await _produtoRepositorio.Adicionar(produto);
                return await Task.FromResult(produto);
            }
            catch (Exception)
            {
                return await Task.FromResult(BadRequest());
            }

            
        }

        //public async Task<IActionResult> ApagarConfirmacao(long id)
        //{
        //    ProdutoModel produto = await _produtoRepositorio.BuscarPorId(id);
        //    return await Task.FromResult(View(produto));
        //}


        //public async Task<IActionResult> Remover(long id)
        //{
        //    ProdutoModel produto = await _produtoRepositorio.BuscarPorId(id);
        //    await _produtoRepositorio.Apagar(produto);
        //    return await Task.FromResult(RedirectToAction("Index"));
        //}

        //public async Task<IActionResult> AlterarEstado(long id)
        //{
        //    ProdutoModel produto = await _produtoRepositorio.BuscarPorId(id);

        //    produto.Ativo = !produto.Ativo;

        //    await _produtoRepositorio.Atualizar(produto);
        //    return await Task.FromResult(RedirectToAction("Index"));

        //}

    }
}
