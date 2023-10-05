using ControleProdutosQ3.Data;
using ControleProdutosQ3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Authentication;

namespace ControleProdutosQ3.Repository
{
    public class ClienteRepositorio : IClienteRepositorio
    {

        private readonly BancoContext _bancoContext;

        public ClienteRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }

        public async Task<bool> Apagar(ClienteModel cliente)
        {
            try
            {
                _bancoContext.Cliente.Remove(cliente);
                await _bancoContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;

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
            
            ClienteModel clienteAlterado = await  BuscarPorId(cliente.Id);

            clienteAlterado.Nome = cliente.Nome;
            clienteAlterado.Telefone = cliente.Telefone;
            clienteAlterado.NomeDaFoto = cliente.NomeDaFoto;
            clienteAlterado.Foto = cliente.Foto;

            await _bancoContext.SaveChangesAsync();
            return clienteAlterado;

        }

        public async Task<ClienteModel> BuscarPorId(long id)
        {
            Task<ClienteModel> clienteDB;

            try
            {
				clienteDB = _bancoContext.Cliente.FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}, ocorreu erro na busca do produto!");
            }

            return await clienteDB;
        }
    }
}
