using ControleProdutosQ3.Models;
using ControleProdutosQ3.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ControleProdutosQ3.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginApiController : Controller
    {
        public const string SessionKeyUser = "_Usuario";
        public const string SessionKeyEmail = "_Email";
        public const string SessionKeyNivel = "_Nivel";
        public const string SessionKeyId = "_Id";

        private readonly ILoginRepositorio _loginRepositorio;

        public LoginApiController(ILoginRepositorio loginRepositorio) 
        {
            this._loginRepositorio = loginRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<LoginModel>> Logar(string? usuario, string? senha)
        {
            LoginModel loginDb = await _loginRepositorio.ListarPorUsuario(usuario);

            var sucesso = false;
            
            if(senha != null && loginDb != null)
            {
                sucesso = Util.Decriptografia(loginDb.Senha, senha);

                if (sucesso)
                {
                    return await Task.FromResult(loginDb);
                }
            }

            return await Task.FromResult(BadRequest());
        }

        public class LoginUsuarioModel
        {
            public string? Usuario { get; set; }
            public string? Email { get; set; }
            public string? Senha { get; set; }
            public int? NivelAcesso { get; set; }


        }

        [HttpPost]
        public async Task<ActionResult<LoginModel>> Logar([FromBody] LoginUsuarioModel loginUsuarioModel )
        {
            LoginModel loginDb = await _loginRepositorio.ListarPorUsuario(loginUsuarioModel.Usuario!);

            var sucesso = false;

            if (loginUsuarioModel.Senha != null && loginDb != null)
            {
                sucesso = Util.Decriptografia(loginDb.Senha, loginUsuarioModel.Senha);

                if (sucesso)
                {
                    return await Task.FromResult(loginDb);
                }
            }

            return await Task.FromResult(BadRequest());
        }

        //      public async Task<IActionResult> Registro()
        //      {
        //          return await Task.FromResult<IActionResult>(View());
        //      }


        //      [HttpPost]
        //      public async Task<IActionResult> Registro(LoginModel login, string? senha)
        //      {
        //          LoginModel loginDB = login;
        //          loginDB.Senha = Util.Criptografia(senha! ?? "123");

        //          loginDB.NivelAcesso = 1;
        //          loginDB.DataRegistro = DateTime.Now;
        //          loginDB.Ativo = true;
        //          loginDB.EmailConfirmado = false;
        //          loginDB.TelefoneConfirmado = false;

        //          await _loginRepositorio.Adicionar(loginDB);

        //          return await Task.FromResult(RedirectToAction("Index", "Home"));
        //      }

        //      [HttpPost]
        //      public async Task<IActionResult> Index(string usuario, string senha)
        //      {
        //          LoginModel loginDB = await _loginRepositorio.ListarPorUsuario(usuario);
        //          var sucesso = false;

        //          if (loginDB.Usuario != null && senha != null) 
        //          {
        //              sucesso = Util.Decriptografia(loginDB.Senha, senha);
        //          }

        //          if (sucesso)
        //          {
        //              // Gravando usuario logado na sessão

        //              HttpContext.Session.SetString(SessionKeyUser, loginDB.Usuario);
        //              HttpContext.Session.SetString(SessionKeyEmail, loginDB.Email);
        //              HttpContext.Session.SetInt32(SessionKeyNivel, loginDB.NivelAcesso);
        //              HttpContext.Session.SetInt32(SessionKeyId, (int) loginDB.Id);

        //		return await Task.FromResult(RedirectToAction("Index", "Home"));


        //	}

        //          return await Task.FromResult(View());
        //      }


        //async public Task<IActionResult> Editar(long id)
        //{
        //	LoginModel login = await _loginRepositorio.ListarPorId(id);

        //	return await Task.FromResult(View(login));
        //}


        //[HttpPost]
        //public async Task<IActionResult> Alterar(LoginModel login, string senhaAtual, string novaSenha)
        //{
        //	LoginModel loginDB = await _loginRepositorio.ListarPorId(login.Id);

        //	if (loginDB != null)
        //	{
        //		if (novaSenha != null)
        //		{
        //			var sucesso = false;
        //			sucesso = Util.Decriptografia(loginDB.Senha, senhaAtual);

        //			if (sucesso)
        //			{
        //				loginDB.Senha = Util.Criptografia(novaSenha);
        //			}
        //		}
        //		else
        //		{
        //			loginDB.Senha = loginDB.Senha;
        //		}
        //		loginDB.Usuario = login.Usuario;
        //		loginDB.Email = login.Email;
        //		loginDB.NivelAcesso = login.NivelAcesso;

        //		await _loginRepositorio.Atualizar(loginDB);
        //		return await Task.FromResult(RedirectToAction("Sair", "Home"));
        //	}

        //	return await Task.FromResult(View());
        //}

    }
}
