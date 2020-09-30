using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Jogame.Domains;
using API_Jogame.Interfaces;
using API_Jogame.Repositories;
using API_Jogame.Utills;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Jogame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadoresController : ControllerBase
    {
        private readonly IJogadorRepository _JogadorRepository;

        public JogadoresController()
        {
            _JogadorRepository = new JogadorRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //lista de jogadores
                var jogadores = _JogadorRepository.LerTodos();

                //verifica se existe no conxtexto atual
                //caso nao exista ele retorna NoContext
                if (jogadores.Count == 0)
                    return NoContent();

                //caso exista retorno Ok e o total de jogadores cadastrados
                return Ok(new
                {
                    totalCount = jogadores.Count,
                    data = jogadores
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //busca jogador por id
                Jogador jog = _JogadorRepository.BuscarPorId(id);

                //faz a verificacao no contexto para ver se o jogador foi encontrado 
                //caso nao for encontrado o sistema retornara NotFound 
                if (jog == null)
                    return NotFound();

                //se existir retorno vai passar o Ok e os dados do jogador  
                return Ok(jog);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromForm] Jogador jogador)
        {
            try
            {

                if (jogador.Imagem != null)
                {
                    var urlImagem = Upload.Local(jogador.Imagem);

                    jogador.UrlImagem = urlImagem;
                }

                //adiciona um novo jogador
                _JogadorRepository.Cadastrar(jogador);

                //retorna Ok se o jogador tiver sido cadastrado
                return Ok(jogador);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Jogador jogador)
        {
            try
            {
                //edita o jogador
                _JogadorRepository.Alterar(jogador);

                //retorna o Ok com os dados do jogador
                return Ok(jogador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //busca o jogador pelo Id
                var jog = _JogadorRepository.BuscarPorId(id);

                //verifica se o jogador existe
                //caso não exista retorna NotFound
                if (jog == null)
                    return NotFound();

                //caso exista remove o jogador
                _JogadorRepository.Excluir(id);
                //retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
