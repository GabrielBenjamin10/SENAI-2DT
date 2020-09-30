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
    public class JogoController : ControllerBase
    {
        private readonly IJogoRepository _JogoRepository;
        public JogoController()
        {
            _JogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Lista os produtos no repositório
                var jogos =  _JogoRepository.LerTodos();

                // verifica  se existe jogos, caso n exista retorna sem conteudo
                if (jogos.Count == 0)
                    return NoContent();

                // Caso exista retorna Ok e os jogos
                return Ok(new { 
                    totalCount = jogos.Count,
                    data = jogos
                });

            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

      
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                // bUSCO o jogo no repositório
                Jogo jogo = _JogoRepository.BuscarPorId(id);

                // verifica se o  jogo existe
                // Caso n esxita retorna notfound
                if (jogo == null)
                    return NotFound();

                // caso o jogo exista retorna ok e seus dados
                return Ok(jogo);
            }
            catch (Exception)
            {
                // Caso ocorra algum erro retorna BadRequest e a mensagem de erro
                return BadRequest(new { 
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/ jogos, envie um e-mail para email@gmail.com informando"
                });
            }
        }

        //fromform - recebe os dados via form-data
        [HttpPost]
        public IActionResult Post([FromForm] List<JogoJogadores> jogoJogadores)
        {
            try
            {
                Jogo jogo = _JogoRepository.Cadastrar(jogoJogadores);

                if (jogo.Imagem != null)
                {
                    var urlImagem = Upload.Local(jogo.Imagem);

                    jogo.UrlImagem = urlImagem;
                }


                return Ok(jogo);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Jogo jogo)
        {
            try
            {
                var jogoTemp = _JogoRepository.BuscarPorId(id);


                // verifica se o  jogo existe
                // Caso n esxita retorna notfound
                if (jogoTemp == null)
                    return NotFound();


                _JogoRepository.Alterar(jogo);

                // retorna ok com os dados do jogo
                return Ok(jogo);

            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

   
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {   // Exclui o jogo no repository
                _JogoRepository.Excluir(id);

                // caso o jogo exista retorna ok e seus dados
                return Ok(id);
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a mensagem de erro
                return BadRequest(ex.Message);
            }
        }
    }
}
