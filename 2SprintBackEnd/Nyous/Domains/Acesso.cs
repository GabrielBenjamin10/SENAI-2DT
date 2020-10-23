using System;
using System.Collections.Generic;

namespace Nyous.Domains
{
    public partial class Acesso
    {
        public Acesso()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdAcesso { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
