using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Jogame.Domains
{
    /// <summary>
    /// Definimos a classe jogador
    /// </summary>
    public class Jogador : BaseDomain
    {
        // Fazemos as propriedades
        public string   Nome            { get; set; }
        public string   Email           { get; set; }
        public string   Senha           { get; set; }
        public DateTime DataNascimento  { get; set; }

        [NotMapped]
        //não mapeia a propriedade no banco de dados
        [JsonIgnore]
        public IFormFile Imagem { get; set; }

        //url da imagem no salva no servidor
        public string UrlImagem { get; set; }

        // relacioanmento coma  tabela jogosjogadores 1,n
        public List<JogoJogadores> JogosJogadores { get; set; }
    }
}
