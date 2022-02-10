using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Model.Entities;

namespace WebApi.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost("/api/login")]
        public async Task<ActionResult> Login(Usuario usuario)
        {
            if(usuario.Nome=="adm" && usuario.Senha == "adm")
            {
                return Ok();
            }
            return BadRequest(error: "Incorreto usuário ou senha");
        }
    }
}
