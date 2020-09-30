using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_ORM.Domains
{
    public abstract class BaseDomain
    {
        /// <summary>
        /// Define a classe Produto
        /// </summary>
        [Key]
        public Guid Id { get; private set; }

        public BaseDomain()
        {
            Id = Guid.NewGuid();
        }
    }
}
