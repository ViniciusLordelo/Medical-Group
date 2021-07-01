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


    // Define que a rota de uma requesição será no formato: porta/api/controller
    [Route("api/[controller]")]


    // Define que é um Controller de API
    [ApiController]


    public class ConsultasController : ControllerBase
    {

        private IConsultas _ConsultaRepository { get; set; }

        public ConsultasController()
        {
            _ConsultaRepository = new ConsultasRepository();
        }


        /// <summary>
        /// Listar consultas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {

            try
            {
                // Retorna um status code Ok(200) e as Consultas
                return Ok(_ConsultaRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400) e mostra vazio
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastrar consultas
        /// </summary>
        /// <returns></returns>

        [HttpPost]

        public IActionResult Cadastrar(Consulta consulta)
        {

            try
            {
                _ConsultaRepository.Cadastrar(consulta);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// deletar consulta
        /// </summary>
        /// <returns></returns>

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]

        public IActionResult Deletar(int id)
        {


            try
            {
                // Cadastra um novo Usuario
                _ConsultaRepository.Deletar(id);

                // Retorna um status code NoContent(204)
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400)
                return BadRequest(erro);
            }


        }

        [HttpPatch("{idConsulta}/{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(int consultaAtualizada)
        {
            throw new NotImplementedException();
        }




    }
}

