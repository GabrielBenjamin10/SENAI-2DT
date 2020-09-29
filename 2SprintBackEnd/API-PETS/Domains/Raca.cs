using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pet.Domains
{
    public class Raca
    {
        public int      IdRaca { get; set; }
        public string   Descricao { get; set; }
        public int      IdTipoPet  { get; set; }
    }
}
