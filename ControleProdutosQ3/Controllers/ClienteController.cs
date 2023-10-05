using ControleProdutosQ3.Models;
using ControleProdutosQ3.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ControleProdutosQ3.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ClienteController(IClienteRepositorio clienteRepositorio, IWebHostEnvironment webHostEnvironment)
        {
            _clienteRepositorio = clienteRepositorio;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            List<ClienteModel> clientes = await _clienteRepositorio.BuscarTodos();

            return await Task.FromResult(View(clientes));
        }

        public async Task<IActionResult> Criar()
        {
            return await Task.FromResult(View());
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ClienteModel cliente, IFormFile? imagemCarregada, string bairro, string cidade, string logradouro) 
        {
           
            if(!ValidaModels.Valida<ClienteModel>(cliente))
            {
                return await Task.FromResult(View(cliente));
            }


            if (imagemCarregada == null)
            {
                cliente.Foto = null;
                cliente.NomeDaFoto = "";
            }
            else
            {
                cliente.Foto = Util.SalvaImagem(imagemCarregada, _webHostEnvironment.WebRootPath);
                cliente.NomeDaFoto = imagemCarregada.FileName;
            }

            cliente.Enderecos.Add(new EnderecoModel
            {
                Bairro = bairro,
                Logradouro = logradouro,
                Cidade = cidade,
                ClienteId = cliente.Id,
                CEP = cliente.CEP

            });


            await _clienteRepositorio.Adicionar(cliente);

            return await Task.FromResult(RedirectToAction("Index"));
        }

        public async Task<IActionResult> Alterar(ClienteModel cliente, IFormFile imagemCarregada)
        {


            if (!ValidaModels.Valida<ClienteModel>(cliente))
            {
                return await Task.FromResult(View(cliente));
            }


            if (imagemCarregada == null)
            {
                cliente.Foto = null;
                cliente.NomeDaFoto = "";
            }
            else
            {
                cliente.Foto = Util.SalvaImagem(imagemCarregada, _webHostEnvironment.WebRootPath);
                cliente.NomeDaFoto = imagemCarregada.FileName;
            }

           


            await _clienteRepositorio.Editar(cliente);

            return await Task.FromResult(RedirectToAction("Index"));
           
        }

        public async Task<IActionResult> Editar(long id)
        {
            ClienteModel cliente = await _clienteRepositorio.BuscarPorId(id);
            return await Task.FromResult(View(cliente));
        }

        public async Task<IActionResult> Atualizar(long id)
        {
            ClienteModel cliente = await _clienteRepositorio.BuscarPorId(id);
            cliente.Ativo = !cliente.Ativo;
            await _clienteRepositorio.Editar(cliente);
            return await Task.FromResult(RedirectToAction("Index"));

        }

        public async Task<IActionResult> ApagarConfirmacao(long id)
        {
            ClienteModel cliente = await _clienteRepositorio.BuscarPorId(id);
            return await Task.FromResult(View(cliente));

        }

        public async Task<IActionResult> Remover(long id)
        {
            ClienteModel cliente = await _clienteRepositorio.BuscarPorId(id);
            await _clienteRepositorio.Apagar(cliente);

            return await Task.FromResult(RedirectToAction("Index"));

        }

    }
}
