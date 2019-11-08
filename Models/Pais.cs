using System;
using System.Collections.Generic;

namespace preciosyav3.Models
{
    public partial class Pais
    {
        public Pais()
        {
            Provincia = new HashSet<Provincia>();
        }

        public int PaId { get; set; }
        public string PaNombre { get; set; }

        public virtual ICollection<Provincia> Provincia { get; set; }
    }
}
