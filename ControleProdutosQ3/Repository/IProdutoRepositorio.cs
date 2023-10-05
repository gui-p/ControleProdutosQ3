using ControleProdutosQ3.Models;

namespace ControleProdutosQ3.Repository
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> BuscarTodos();
        Task<ProdutoModel> Adicionar(ProdutoModel produto);
        Task<ProdutoModel> BuscarPorId(long id);
        Task<ProdutoModel> Atualizar(ProdutoModel produto);
        Task<bool> Apagar(ProdutoModel produto);
    }
}
