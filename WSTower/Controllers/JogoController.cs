using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.Domains;
using WSTower.Repositories;

namespace WSTower.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        JogoRepository jogoRepository = new JogoRepository();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(jogoRepository.ListarJogos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("Estadio/{estadio}")]
        public IActionResult BuscarPorEstadio(string estadio)
        {
            Jogo jogo = jogoRepository.BuscarPorEstadio(estadio);
            if (jogo == null)
            {
                return NotFound("Não há jogos nesse estadio");
            }
            return Ok(jogo);
        }

        /*[HttpGet]
        public IActionResult PlacarConfronto()
        {
            return Ok(jogoRepository.PlacarFinal());
        }/*/

        /*[HttpGet]
        [Route("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Jogo jogo = jogoRepository.BucarPorId(id);
            if (jogo == null)
            {
                return NotFound();
            }
            return Ok(jogo);
        }/*/

        [HttpGet("Data/{data}")]
        public IActionResult BuscarPorData(DateTime data)
        {
            Jogo jogo = jogoRepository.BuscarPorData(data);
            if (jogo == null)
            {
                return NotFound("Nesta data não há jogos");
            }
            return Ok(jogo);
        }

        [HttpGet("Selecao/{selecao}")]
        public IActionResult BuscarPorSelecao(string selecao)
        {
            Jogo jogo = jogoRepository.BuscarPorSelecao(selecao);
            if (jogo == null)
            {
                return NotFound("Está seleção não participou de jogos");
            }
            return Ok(jogo);
        }

        [HttpPost]
        public IActionResult Cadastrar(Jogo jogo)
        {
            try
            {
                jogoRepository.Cadastrar(jogo);
                return StatusCode(201, "Jogo Cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Algo deu errado");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            jogoRepository.Deletar(id);
            return Ok("jogo deletado com sucesso");
        }

        [HttpPut]
        public IActionResult Atualizar(Jogo jogo)
        {
            try
            {
                Jogo jogoBuscado = jogoRepository.BucarPorId(jogo.Id);
                if (jogoBuscado == null)
                    return NotFound();
                jogoRepository.Atualizar(jogoBuscado);
                return Ok("Jogo atualizado com sucesso");

                
            }
            catch (Exception)
            {

                return BadRequest("Algo deu errado");
            }
        }
    }
}
