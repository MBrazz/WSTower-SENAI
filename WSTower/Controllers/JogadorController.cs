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
    public class JogadorController : ControllerBase
    {
        JogadorRepository jogadorRepository = new JogadorRepository();

        //Metodo que lista os Jogadores

        /*[HttpGet]
        public IActionResult ListarJogadores()
        {
            return Ok(jogadorRepository.Listar());
        }/*/

        //Metodo que lista os jogadores com as informaçoes da seleçao tambem

        [HttpGet]
        public IActionResult ListarComSelecoes()
        {
            return Ok(jogadorRepository.ListarComSelecao());
        }

        [HttpPost]
        public IActionResult Cadastrar(Jogador jogador) 
        {
            try
            {
                jogadorRepository.Cadastar(jogador);
                return StatusCode(201, "O jogador foi cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Algo deu errado na hora de cadastrar");
            }
        }

        [HttpGet("Nome/{nome}")]
        public IActionResult BuscarPorId(string nome)
        {
            Jogador jogador = jogadorRepository.BuscarPorNome(nome);
            if (jogador == null)
            {
                return NotFound("Jogador não encontrado");
            }
            
            return Ok(jogador);
        }

        [HttpPut]
        public IActionResult Atualizar(Jogador jogador)
        {
            try
            {
                Jogador jogadorBuscado = jogadorRepository.BuscarPorId(jogador.Id);
                if (jogadorBuscado == null)
                    return NotFound();
                jogadorRepository.Atualizar(jogador);
                return Ok("Jogador atualizado com sucesso");

                
            }
            catch (Exception)
            {

                return BadRequest("Algo deu errado");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            jogadorRepository.Deletar(id);
            return StatusCode(202, "Jogador deletado com sucesso");
        }

        [HttpGet("Selecao/{selecaoid}")]
        public IActionResult BuscarPorSelecao(int selecaoid)
        {
            Jogador jogador = jogadorRepository.BuscarPorSelecao(selecaoid);
            if (jogador == null)
            {
                return NotFound("Jogador não encontrado");
            }

            return Ok(jogador);
        }
    }
}
