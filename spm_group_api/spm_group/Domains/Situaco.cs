using System;
using System.Collections.Generic;

#nullable disable

namespace spm_group.Domains
{
    public partial class Situaco
    {
        public Situaco()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdSituacao { get; set; }
        public string Titulo { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
