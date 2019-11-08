using System;
using System.Collections.Generic;

namespace preciosyav3.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Comercio = new HashSet<Comercio>();
        }

        public int ProId { get; set; }
        public string ProNombre { get; set; }
        public decimal? ProPrecio { get; set; }
        public bool ProDisponible { get; set; }
        public string ProDescripcion { get; set; }
        public int? ProMaId { get; set; }

        public virtual Marca ProMa { get; set; }
        public virtual ICollection<Comercio> Comercio { get; set; }
    }
}
