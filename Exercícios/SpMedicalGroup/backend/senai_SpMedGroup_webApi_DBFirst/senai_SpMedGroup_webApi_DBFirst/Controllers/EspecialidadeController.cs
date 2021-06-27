using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_SpMedGroup_webApi_DBFirst.Domains;
using senai_SpMedGroup_webApi_DBFirst.Interfaces;
using senai_SpMedGroup_webApi_DBFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]


    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }


        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _especialidadeRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Especialidade novaEspecialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(novaEspecialidade);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Especialidade especialidadeAtualizada)
        {
            try
            {
                _especialidadeRepository.Atualizar(id, especialidadeAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_especialidadeRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_especialidadeRepository.BuscarPorId(id));


            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}