using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
    public class SelecaoController : ControllerBase
    {
        SelecaoRepository selecaoRepository = new SelecaoRepository();

        [HttpGet]
        public IActionResult ListarSelecoes()
        {
            return Ok(selecaoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Selecao selecao)
        {
            try
            {
                 selecaoRepository.Cadastrar(selecao);
                return StatusCode(201, "Seleção cadastrada com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Algo deu errado");
            }
        }

        [HttpGet]
        [Route("{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            Selecao selecao = selecaoRepository.BuscarPorNome(nome);
            if (selecao == null)
            {
                return NotFound("Seleção não encontrada");
            }

            return Ok(selecao);
        }
    }
}
