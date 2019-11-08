using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace preciosyav3.Models
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            Comercio = new HashSet<Comercio>();
        }

        public int UbId { get; set; }
        public Geometry UbUbicacion { get; set; }
        public int? UbParId { get; set; }

        public virtual Partido UbPar { get; set; }
        public virtual ICollection<Comercio> Comercio { get; set; }
    }
}
