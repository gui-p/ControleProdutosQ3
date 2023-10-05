using ControleProdutosQ3.Models;

namespace ControleProdutosQ3.Repository
{
    public interface ILoginRepositorio
    {
        Task<LoginModel> Adicionar(LoginModel login);
        Task<LoginModel> ListarPorId(long id);
        Task<LoginModel> ListarPorUsuario(string usuario);
        Task<LoginModel> ListarPorEmailSenha(string email, string senha);

        Task<LoginModel> ListarPorEmail(string email);
        Task<LoginModel> Atualizar(LoginModel login);
        Task<bool> Apagar(long id);
    }
}
