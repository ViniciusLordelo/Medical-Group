using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spm_group.Interfaces;
using spm_group.Repositories;
using spm_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spm_group.Controllers
{
    // Define que a resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requesição será no formato: dominio/api/controller
    [Route("api/[controller]")]

    // Define que é um Controller de API
    [ApiController]
    
    public class UsuariosController : ControllerBase
    {

        private IUsuario _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }


        //lista os usuarios

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                // Retorna um status code Ok(200) e uma lista de Usuarios
                return Ok(_UsuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400)
                return BadRequest(erro);
            }
        }




        //cadastra um usuario

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                // Cadastra um novo Usuario
                _UsuarioRepository.Cadastrar(usuario);

                // Retorna um status code Created(201)
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400)
                return BadRequest(erro);
            }
        }


        //deleta um usuario

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                // Cadastra um novo Usuario
                _UsuarioRepository.Deletar(id);

                // Retorna um status code NoContent(204)
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400)
                return BadRequest(erro);
            }
        }




    }
}
