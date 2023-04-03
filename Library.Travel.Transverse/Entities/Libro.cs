using System.ComponentModel.DataAnnotations;

namespace Library.Travel.Transverse.Entities
{
    public class Libro
    {
        [Key]
        public int ISBN { get; set; }
        public int Editoriales_Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Sinopsis { get; set; } = string.Empty;
        public string N_Paginas { get; set; } = string.Empty;

        public Editorial? Editorial { get; set; }
        public ICollection<Autores_Has_Libros>? Autores_Has_Libros { get; set; }
    }
}
