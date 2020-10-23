using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFCore.Domains
{
    /// <summary>
    /// Define a classe produto
    /// </summary>
    public class Produto : BaseDomain
    {
        // guid - codigo unico de identificacao
        public string   Nome { get; set; }
        public float    Preco { get; set; }
        // Serve como uma classificação da seguinte propriedade
        [NotMapped] // Para que ela não seja mapeada no database
        [JsonIgnore]// Ignore a propriedade no retorno do Json
        public IFormFile Imagem { get; set; }
        // Url da imagem do produto salva no servidor
        public string UrlImagem { get; set; }

        //Relacioanamento com a tabela PedidoItem one to many
        public List<PedidoItem> PedidoItens { get; set; }
    }
}
