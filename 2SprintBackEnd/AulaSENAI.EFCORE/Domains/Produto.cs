using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api_ORM.Domains
{
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }
        [NotMapped]//nao mapea a entidade no bando de dados
        [JsonIgnore]
        public IFormFile Imagem { get; set; }
        public string UrlImagem { get; set; }

        //relacionamento com a tabela pedidoitem 1 pra N
        public List<PedidoItem> PedidoItem { get; set; }

    }
}
