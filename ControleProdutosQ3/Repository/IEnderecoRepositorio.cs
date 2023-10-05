using ControleProdutosQ3.Models;

namespace ControleProdutosQ3.Repository
{
    public interface IEnderecoRepositorio
    {
        Task<List<EnderecoModel>> BuscarTodos();

        Task<EnderecoModel> Adicionar(EnderecoModel endereco);

        Task<EnderecoModel> ListarPorId(long id);
        Task<EnderecoModel> ListarPorCEP(string CEP);

        Task<EnderecoModel> Atualizar(EnderecoModel endereco);

        Task<bool> Apagar(long id);


    }
}
