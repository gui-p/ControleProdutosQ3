using ControleProdutosQ3.Data;
using ControleProdutosQ3.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleProdutosQ3.Repository
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {

        private readonly BancoContext _bancoContext;

        public ProdutoRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }

        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _bancoContext.Produto.AddAsync(produto);
            await _bancoContext.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> Apagar(ProdutoModel produto)
        {
            try
            {
                _bancoContext.Produto.Remove(produto);
                await _bancoContext.SaveChangesAsync();

            }catch (Exception ex)
            {
                return false;
            }

            return true;

        }



        public async Task<ProdutoModel> Atualizar(ProdutoModel produto)
        {

            //Null check
            ProdutoModel produtoDb = await BuscarPorId(produto.Id) ?? throw new Exception("Erro na atualização do produto");

            produtoDb.Descricao = produto.Descricao;
            produtoDb.CodigoDeBarras = produto.CodigoDeBarras;
            produtoDb.Valor = produto.Valor;
            produtoDb.DataDeValidade = produto.DataDeValidade;
            produtoDb.CodigoDeBarras = produto.CodigoDeBarras;
            produtoDb.Quantidade = produto.Quantidade;
            produtoDb.NomeDaFoto = produto.NomeDaFoto;
            produtoDb.Foto = produto.Foto;
            produtoDb.Ativo = produto.Ativo;

            _bancoContext.Update(produtoDb);

            await _bancoContext.SaveChangesAsync();

            return await Task.FromResult(produtoDb);
        }

        public async Task<ProdutoModel> BuscarPorId(long id)
        {
            Task<ProdutoModel> produtoDB;

            try
            {
                produtoDB = _bancoContext.Produto.FirstOrDefaultAsync(p => p.Id == id);
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}, ocorreu erro na busca do produto!");
            }

            return await produtoDB;
        }

        public async Task<List<ProdutoModel>> BuscarTodos()
        {
            return await _bancoContext.Produto.ToListAsync();
        }
    }
}
