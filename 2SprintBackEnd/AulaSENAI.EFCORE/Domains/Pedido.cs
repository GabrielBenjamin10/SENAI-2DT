using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domains
{
    public class Pedido : BaseDomain
    {
        public string   Status { get; set; }
        public DateTime OrderDate { get; set; }

        //Relacioanamento com a tabela PedidoItem one to many
        public List<PedidoItem> PedidosItens { get; set; }

        public Pedido()
        {
            PedidosItens = new List<PedidoItem>();
        }



    }
}
