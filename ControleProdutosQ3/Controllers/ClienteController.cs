using ControleProdutosQ3.Models;
using ControleProdutosQ3.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ControleProdutosQ3.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            List<ClienteModel> clientes = await _clienteRepositorio.BuscarTodos();

            return await Task.FromResult(View(clientes));
        }
        
        public async Task<IActionResult> Criar(ClienteModel cliente) 
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(cliente);

            bool isValid = Validator.TryValidateObject(cliente, context, results, true);
            if(!isValid)
            {
                return await Task.FromResult(View(cliente));
            }

            cliente.Status = 1;

            await _clienteRepositorio.Adicionar(cliente);

            return await Task.FromResult(RedirectToAction("Index"));
        }

        public async Task<IActionResult> Editar(ClienteModel cliente)
        {
            
            return await Task.FromResult(View(cliente));
           
        }

        public async Task<IActionResult> EditarConfirmar(ClienteModel cliente)
        {
            await _clienteRepositorio.Editar(cliente);
            return await Task.FromResult(RedirectToAction("Index"));
        }

    }
}
