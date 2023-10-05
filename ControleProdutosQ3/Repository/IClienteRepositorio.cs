using ControleProdutosQ3.Models;

namespace ControleProdutosQ3.Repository
{
    public interface IClienteRepositorio
    {

        Task<List<ClienteModel>> BuscarTodos();

        Task<ClienteModel> Adicionar(ClienteModel cliente);

        Task<ClienteModel> Editar(ClienteModel cliente);

        Task<bool> Apagar(ClienteModel cliente);

        Task<ClienteModel> BuscarPorId(long id);

    }
}
