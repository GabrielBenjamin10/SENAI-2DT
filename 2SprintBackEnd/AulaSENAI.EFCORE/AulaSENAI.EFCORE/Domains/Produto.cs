﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AulaSENAI.EFCORE.Domains
{
    public class Produto:BaseDomain
    {
      
        public string Nome { get; set; }
        public float Preco { get; set; }

        

    }
}
