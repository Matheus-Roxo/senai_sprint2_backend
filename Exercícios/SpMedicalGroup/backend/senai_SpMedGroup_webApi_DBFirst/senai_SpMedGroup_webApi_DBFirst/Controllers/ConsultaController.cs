using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_SpMedGroup_webApi_DBFirst.Domains;
using senai_SpMedGroup_webApi_DBFirst.Interfaces;
using senai_SpMedGroup_webApi_DBFirst.Repositories;
using senai_SpMedGroup_webApi_DBFirst.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.Controllers
{ 

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]


public class ConsultaController : ControllerBase
{

    private IConsultaRepository _consultaRepository { get; set; }


    public ConsultaController()
    {
        _consultaRepository = new ConsultaRepository();
    }

    [Authorize(Roles = "1")]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _consultaRepository.Deletar(id);

            return StatusCode(204);
        }
        catch (Exception erro)
        {
            return BadRequest(erro);
        }
    }


    [Authorize(Roles = "1")]
    [HttpPost]
    public IActionResult Post(Consulta novaConsulta)
    {
        try
        {
            _consultaRepository.Cadastrar(novaConsulta);

            return StatusCode(201);
        }
        catch (Exception erro)
        {
            return BadRequest(erro);
        }
    }


    [Authorize(Roles = "1")]
    [HttpPut("{id}")]
    public IActionResult Put(int id, Consulta consultaAtualizada)
    {
        try
        {
            _consultaRepository.Atualizar(id, consultaAtualizada);

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
            return Ok(_consultaRepository.Listar());

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
            return Ok(_consultaRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro);
        }
    }

    [Authorize(Roles = "1")]
    [HttpPatch("{idConsulta}/{idStatus}")]
    public IActionResult Patch(int idConsulta, int idStatus)
    {
        try
        {
            _consultaRepository.AtualizarStatusConsulta(idConsulta, idStatus);

            return StatusCode(204);
        }
        catch (Exception erro)
        {
            return BadRequest(erro);
        }
    }


    [Authorize(Roles = "3")]
    [HttpPatch("{id}")]
    public IActionResult Path(int id, ConsultaViewModel atualizarDescricao)
    {
        try
        {
            _consultaRepository.AtualizarDescricaoConsulta(id, atualizarDescricao);

            return StatusCode(204);
        }
        catch (Exception erro)
        {
            return BadRequest(erro);
        }
    }


    [Authorize(Roles = "2,3")]
    [HttpGet("Minhas")]
    public IActionResult GetMy()
    {
        try
        {
            int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

            return Ok(_consultaRepository.ListarConsultas(idUsuario));


        }
        catch (Exception erro)
        {
            return BadRequest(new
            {
                mensagem = "Não foi possível mostrar suas contas pois você não está logado",
                erro
            });
        }
    }

    }
}

