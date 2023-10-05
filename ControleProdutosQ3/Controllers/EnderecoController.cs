using ControleProdutosQ3.Models;
using ControleProdutosQ3.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace ControleProdutosQ3.Controllers
{
    public class EnderecoController : Controller
    {

        public const string SessionKeyUser = "_Usuario";
        public const string SessionKeyEmail = "_Email";
        public const string SessionKeyNivel = "_Nivel";



        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public EnderecoController(IEnderecoRepositorio endereco) 
        { 
            this._enderecoRepositorio = endereco;
        }


        public async Task<IActionResult> Index()
        {

            List<EnderecoModel> enderecos = await _enderecoRepositorio.BuscarTodos();

            var usuario = HttpContext.Session.GetString(SessionKeyUser);
            if (!usuario.IsNullOrEmpty()) return await Task.FromResult(View(enderecos));
            
            return await Task.FromResult(RedirectToAction("Index", "Home"));
        }

        [HttpGet]
        public async Task<IActionResult> EnderecosCliente(long clienteId)
        {
            List<EnderecoModel> enderecos = await _enderecoRepositorio.BuscarTodos();
            var enderecosFiltrados = enderecos.Where(endereco => endereco.ClienteId == clienteId);
            var usuario = HttpContext.Session.GetString(SessionKeyUser);
            if (!usuario.IsNullOrEmpty()) return await Task.FromResult(View(enderecosFiltrados));

            return await Task.FromResult(RedirectToAction("Index", "Home"));
        }


        public async Task<IActionResult> Criar()
        {
            return await Task.FromResult(View());
        }

        public async Task<IActionResult> Editar(long id)
        {
            return await Task.FromResult(View(await _enderecoRepositorio.ListarPorId(id)));
        }

        public async Task<IActionResult> ApagarConfirmacao(long id)
        {
            EnderecoModel endereco = await _enderecoRepositorio.ListarPorId(id);

            return await Task.FromResult(View(endereco));
        }

        public async Task<IActionResult> Apagar(long id)
        {

            await _enderecoRepositorio.Apagar(id);
            return await Task.FromResult(RedirectToAction("Index"));

        }

        [HttpPost]
        public async Task<IActionResult> Criar(EnderecoModel endereco)
        {
            if (ValidaModels.Valida(endereco))
            {
                return View(endereco);
            }

            await _enderecoRepositorio.Adicionar(endereco);

            return await Task.FromResult(RedirectToAction("Index"));
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(EnderecoModel endereco)
        {
            await _enderecoRepositorio.Atualizar(endereco);
            return await Task.FromResult(RedirectToAction("Index"));

        }


    }
}
