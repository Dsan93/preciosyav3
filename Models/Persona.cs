using System;
using System.Collections.Generic;

namespace preciosyav3.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int PerId { get; set; }
        public string PerNombre { get; set; }
        public string PerApellido { get; set; }
        public int PerDni { get; set; }
        public string PerCorreo { get; set; }
        public string PerGenero { get; set; }
        public bool TipoUsuario { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
