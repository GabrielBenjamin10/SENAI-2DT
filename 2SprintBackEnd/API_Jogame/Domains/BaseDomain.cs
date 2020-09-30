using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Domains
{
    // abstract serve para uam questão de sugurança, fazendo com que a classe n poderá ser instanciada sozinha
    public abstract class BaseDomain
    {
        [Key]
        public Guid Id { get; private set; } // Encapsulamento da propriedade que gera o id pk

        public BaseDomain()
        {
            Id = Guid.NewGuid();
        }

        public void setId(Guid id)
        {
            Id = id;
        }
    }
}
