using System;
using System.Collections.Generic;

namespace preciosyav3.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Comercio = new HashSet<Comercio>();
        }

        public int UsId { get; set; }
        public string UsPassw { get; set; }
        public string UsNickname { get; set; }
        public bool? UsBitreg { get; set; }
        public int UsPerId { get; set; }

        public virtual Persona UsPer { get; set; }
        public virtual ICollection<Comercio> Comercio { get; set; }
    }
}
