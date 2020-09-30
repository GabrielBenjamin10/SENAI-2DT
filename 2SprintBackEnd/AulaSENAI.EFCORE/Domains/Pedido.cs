using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_ORM.Domains
{
    public class Pedido : BaseDomain
    {
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public List<PedidoItem> PedidosItens{ get; set; }
        public List<PedidoItem> PedidoItem { get; internal set; }
    }
}
