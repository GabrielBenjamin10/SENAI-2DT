using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AulaSENAI.EFCORE.Domains;
using AulaSENAI.EFCORE.Interfaces;
using AulaSENAI.EFCORE.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AulaSENAI.EFCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController()
        {
            _pedidoRepository = new PedidoRepository();
        }

        [HttpPost]
        public IActionResult Post(List<PedidoItem> pedidoItems)
        {
            try
            {
                Pedido pedido = _pedidoRepository.Adicionar(pedidoItems);
                return Ok(pedido);

            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pedido = _pedidoRepository.Listar();

                if (pedido.Count == 0)
                    return NoContent();

                return Ok(pedido);

            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var pedido = _pedidoRepository.BuscarPorId(id);

                if (pedido == null)
                    return NotFound();

                return Ok(pedido);

            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
