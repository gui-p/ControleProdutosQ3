using ControleProdutosQ3.Models;

namespace ControleProdutosQ3.Repository
{
    public interface IProdutoRepositorio
    {
        public Task<List<ProdutoModel>> BuscarTodos();
        public Task<ProdutoModel> Adicionar(ProdutoModel produto);
    }
}
