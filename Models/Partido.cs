using System;
using System.Collections.Generic;

namespace preciosyav3.Models
{
    public partial class Partido
    {
        public Partido()
        {
            Ubicacion = new HashSet<Ubicacion>();
        }

        public int ParId { get; set; }
        public string ParNombre { get; set; }
        public int? ParPrId { get; set; }

        public virtual Provincia ParPr { get; set; }
        public virtual ICollection<Ubicacion> Ubicacion { get; set; }
    }
}
