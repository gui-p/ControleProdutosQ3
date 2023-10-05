using ControleProdutosQ3.Data;
using ControleProdutosQ3.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleProdutosQ3.Repository
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {

        private readonly BancoContext _bancoContext;
        public EnderecoRepositorio(BancoContext bancoContext)
        {

            _bancoContext = bancoContext;

        }

        public async Task<EnderecoModel> Adicionar(EnderecoModel endereco)
        {
            await _bancoContext.Endereco.AddAsync(endereco);
            await _bancoContext.SaveChangesAsync();

            return endereco;
            
        }

        public async Task<bool> Apagar(long id)
        {
            
            try
            {
                EnderecoModel endereco = await ListarPorId(id) ?? throw new Exception("Houve um erro ao apagar esse endereço");
                _bancoContext.Endereco.Remove(endereco);
                await _bancoContext.SaveChangesAsync();
            }catch(Exception ex)
            {
                return false;
            }
            
            return true;

        }

        public async Task<EnderecoModel> Atualizar(EnderecoModel endereco)
        {
            EnderecoModel enderecoBanco = await ListarPorId(endereco.Id) ?? throw new Exception("Houve um erro na atualização do endereço");

            enderecoBanco.CEP = endereco.CEP;
            enderecoBanco.Bairro = endereco.Bairro;
            enderecoBanco.Cidade = endereco.Cidade;
            enderecoBanco.Logradouro = endereco.Logradouro;
            enderecoBanco.Cliente = endereco.Cliente;
            enderecoBanco.ClienteId = endereco.ClienteId;

            _bancoContext.Endereco.Update(enderecoBanco);
            await _bancoContext.SaveChangesAsync();

            return await Task.FromResult(enderecoBanco);
        }

        public async Task<List<EnderecoModel>> BuscarTodos()
        {
            return await _bancoContext.Endereco.ToListAsync();

        }

        public async Task<EnderecoModel> ListarPorCEP(string CEP)
        {
            EnderecoModel? enderecoBanco;

            try
            {
                enderecoBanco = await _bancoContext.Endereco.FirstOrDefaultAsync(x => x.CEP == CEP);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Erro ao buscar um endereço");
            }

            return await Task.FromResult(enderecoBanco);

        }

        public async Task<EnderecoModel> ListarPorId(long id)
        {
            EnderecoModel? enderecoBanco;

            try
            {
                enderecoBanco = await _bancoContext.Endereco.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch(Exception ex)
            {
                throw new System.Exception("Erro ao buscar um endereço");
            }

            return await Task.FromResult(enderecoBanco);

        }
    }
}
