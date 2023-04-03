using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Travel.Transverse.Entities
{
    public class LibroDetalle
    {
        public int ISBN { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string AutorNombre { get; set; } = string.Empty;
        public string AutorApellidos { get; set; } = string.Empty;
        public string EditorialNombre { get; set; } = string.Empty;
        public string EditorialSede { get; set; } = string.Empty;
        public string Sinopsis { get; set; } = string.Empty;
        public string NPaginas { get; set; } = string.Empty;
    }
}
