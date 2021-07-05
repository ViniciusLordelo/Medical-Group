using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spm_group.Domains;
using spm_group.Interfaces;
using spm_group.Repositories;
using spm_group.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace spm_group.Controllers
{

    // Define que a resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requesição será no formato: dominio/api/nomedocontroller
    [Route("api/[controller]")]

    // Define que é um Controller de API
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IUsuario _UsuarioRepository { get; set; }

        public LoginController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }



        [HttpPost]

        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuario = _UsuarioRepository.Login(login.Email, login.Senha);

                if (usuario == null)

                {
                    return NotFound("E-mail ou senha inválidos!");
                }

                var claims = new[]
                {
                                               //TipodaClaim, ValorDaClaim
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email) ,
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString()),
                    new Claim("role", usuario.IdTipoUsuario.ToString())

                };


                //define a chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmg-seguranca-login"));


                //define as credenciais do token - Header
                var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Gera o token
                var token = new JwtSecurityToken(
                
                    issuer : "SPMG.WEBAPI",         //DEFINE O EMOSSOR DO TOKEN
                    audience : "SPMG.WEBAPI",       //DESTINO DO TOKEN
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credenciais

                );

                // Retorna um status code Ok(200) com o token criado
                return Ok(new
                {
                    // Gera o token com base nas informações definidas anteriormente e retorna junto com o status code
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });


                }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

    }
}
