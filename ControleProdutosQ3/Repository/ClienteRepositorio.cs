using ControleProdutosQ3.Data;
using ControleProdutosQ3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ControleProdutosQ3.Repository
{
    public class ClienteRepositorio : IClienteRepositorio
    {

        private readonly BancoContext _bancoContext;

        public ClienteRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }

        public void Apagar(ClienteModel cliente)
        {
            throw new NotImplementedException();
        }

        public async Task<ClienteModel> Adicionar(ClienteModel cliente)
        {
            await _bancoContext.Cliente.AddAsync(cliente);
            await _bancoContext.SaveChangesAsync();
            return cliente; 
        }

        public async Task<List<ClienteModel>> BuscarTodos()
        {

            return await _bancoContext.Cliente.ToListAsync();
            
        }

        public async Task<ClienteModel> Editar(ClienteModel cliente)
        {
            
            ClienteModel clienteAlterado = _bancoContext.Cliente.First(a => a.Id == cliente.Id);

            clienteAlterado.Nome = cliente.Nome;
            clienteAlterado.CEP = cliente.CEP;
            clienteAlterado.Telefone = cliente.Telefone;
            await _bancoContext.SaveChangesAsync();
            return clienteAlterado;

        }
    }
}
