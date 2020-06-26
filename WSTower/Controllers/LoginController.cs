using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WSTower.Domains;
using WSTower.Repositories;
using WSTower.ViewModels;

namespace WSTower.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        UsuarioRepository _usuarioRepository = new UsuarioRepository();


        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="login">Objeto login que contém o e-mail e a senha do usuário</param>
        /// <returns>Retorna um token com as informações do usuário</returns>
        /// <response code="200">Retorna o token gerado</response>
        /// <response code="400">Retorna o erro gerado com uma mensagem personalizada</response>
        /// dominio/api/Login
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Usuario, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("E-mail / Apelido ou Senha inválidos!");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),

                    new Claim(ClaimTypes.Role, "Usuario")
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("wstower-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "WSTower",                       // emissor do token
                    audience: "WSTower",                     // destinatário do token
                    claims: claims,                          // dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),    // tempo de expiração
                    signingCredentials: creds                // credenciais do token
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não foi possível gerar o token",
                    error
                });
            }
        }
    }
}
