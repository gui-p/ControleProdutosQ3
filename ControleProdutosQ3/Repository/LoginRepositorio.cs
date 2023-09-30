using ControleProdutosQ3.Data;
using ControleProdutosQ3.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleProdutosQ3.Repository
{
    public class LoginRepositorio : ILoginRepositorio
    {

        private readonly BancoContext _bancoContext;

        public LoginRepositorio(BancoContext banco) 
        {
            this._bancoContext = banco;
        }

        public async Task<LoginModel> Adicionar(LoginModel login)
        {
            await _bancoContext.Login.AddAsync(login);
            await _bancoContext.SaveChangesAsync();
            return await Task.FromResult(login);
        }

        public async Task<bool> Apagar(long id)
        {
            LoginModel login = await ListarPorId(id) ?? throw new System.Exception("Erro ao apagar o login");
            _bancoContext.Login.Remove(login);
            return await Task.FromResult(true);

        }

        public async Task<LoginModel> Atualizar(LoginModel login)
        {
            LoginModel loginDB = await ListarPorId(login.Id) ?? throw new System.Exception("Erro ao atualizar o login");

            loginDB.Usuario= login.Usuario;
            loginDB.Email= login.Email;
            loginDB.Senha= login.Senha;
            loginDB.NivelAcesso= login.NivelAcesso;
            loginDB.Ativo= login.Ativo;

            _bancoContext.Login.Update(loginDB);
            await _bancoContext.SaveChangesAsync();
            return await Task.FromResult(loginDB);

        }

        public async Task<LoginModel> ListarPorUsuario(string usuario)
        {
            return await _bancoContext.Login.FirstOrDefaultAsync(x => x.Usuario.Equals(usuario));
            
        }

        public async Task<LoginModel> ListarPorEmailSenha(string email, string senha)
        {
            LoginModel? login = await _bancoContext.Login.FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Senha.Equals(senha));
            return (login == null) ? new LoginModel() : login;
        }

        public async Task<LoginModel> ListarPorId(long id)
        {

            LoginModel? login = await _bancoContext.Login.FirstOrDefaultAsync(x => x.Id == id);
            return (login!.Equals(null)) ? new LoginModel() : login;

        }
    }
}
