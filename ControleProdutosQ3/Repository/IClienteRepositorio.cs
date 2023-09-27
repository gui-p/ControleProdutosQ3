using ControleProdutosQ3.Models;

namespace ControleProdutosQ3.Repository
{
    public interface IClienteRepositorio
    {

        public Task<List<ClienteModel>> BuscarTodos();

        public Task<ClienteModel> Adicionar(ClienteModel cliente);

        public Task<ClienteModel> Editar(ClienteModel cliente);

        public void Apagar(ClienteModel cliente);


    }
}
