using Indicadores.BL.Class;
using Indicadores.DA.Interface;
using Indicadores.Model.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Indicadores.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _config;
        private TokenUsuarioBL _tokenUsuarioBL;
        public AuthenticationController(IConfiguration config, ITokenUsuarioDA tokenUsuarioDA) //ctor
        {

            _config = config;
            _tokenUsuarioBL = new TokenUsuarioBL(tokenUsuarioDA);

        }

        private string CrearToken(TokenUsuario tokenUsuario)
        {
            var llaveSeguridad = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credenciales = new SigningCredentials(llaveSeguridad, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], 
                 _config["Jwt:Audience"], 
                 null,
                 expires: DateTime.Now.AddMinutes(5),
                 signingCredentials: credenciales)
                 ;

            return new JwtSecurityTokenHandler().WriteToken(token) ;
        }

        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> Login(TokenUsuario login)
        {
            IActionResult res= Unauthorized();
            var usuario = await _tokenUsuarioBL.AutenticarUsuario(login);

            if (login != null && usuario.Estado == 0)
            {
                var token = CrearToken(login);
                res= Ok(new {
                    Usuario = login.Usuario,
                    Estado = usuario.Estado,
                    Mensaje = usuario.Mensaje,
                    Token = token,
                });
            }
            else
            {
                res = Ok(new { 
                    Estado = usuario.Estado,
                    Mensaje = usuario.Mensaje,
                });
            }
             return res;
                
        }
    }
}
