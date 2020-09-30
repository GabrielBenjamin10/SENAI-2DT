using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_Jogame.Domains
{
    public class Jogo : BaseDomain
    {
        public string   Nome            { get; set; }
        public string   Descricao       { get; set; }
        public DateTime DataLancamento  { get; set; }

        [NotMapped]
        // Não mapeia a propriedade no banco de dados

        [JsonIgnore] // Ignore propriedade no retorno no Json

        public IFormFile Imagem { get; set; }

        // Url da imagem  do jogo salva no servidor
        public string UrlImagem { get; set; }

        public List<JogoJogadores> JogosJogadores { get; set; }

        public Jogo()
        {
            JogosJogadores = new List<JogoJogadores>();
        }
    }
}
