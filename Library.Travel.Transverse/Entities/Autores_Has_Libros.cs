using Library.Travel.Domain.Aggregates.LibraryTravel;

namespace Library.Travel.Transverse.Entities
{
    public class Autores_Has_Libros
    {
        public int Autores_Id { get; set; }
        public int Libros_ISBN { get; set; }

        public Autor? Autor { get; set; }
        public Libro? Libro { get; set; }
    }
}
