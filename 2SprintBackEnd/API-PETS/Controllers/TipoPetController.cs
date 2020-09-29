using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Pet.Domains;
using API_Pet.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Pet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPetController : ControllerBase
    {
        //Aqui chamamos o a classe responsavel pela ligacao
        TipoPetRepository rep = new TipoPetRepository();

        // GET: api/<TipoPetController>
        [HttpGet]
        public List<TipoPet> Get()
        {
            return rep.LerTodos();
        }

        // GET api/<TipoPetController>/5
        [HttpGet("{id}")]
        public TipoPet Get(int id)
        {
            return rep.BuscarPorId(id);
        }

        // POST api/<TipoPetController>
        [HttpPost]
        public TipoPet Post([FromBody] TipoPet t)
        {
            return rep.Cadastrar(t);
        }

        // PUT api/<TipoPetController>/5
        [HttpPut("{id}")]
        public TipoPet Put(int id, [FromBody]TipoPet t)
        {
            return rep.Alterar(id, t);
        }

        // DELETE api/<TipoPetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rep.Excluir(id);
        }
    }
}
