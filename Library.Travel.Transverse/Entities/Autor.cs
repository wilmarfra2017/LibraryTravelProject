using Library.Travel.Transverse.Entities;

namespace Library.Travel.Domain.Aggregates.LibraryTravel
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;

        public ICollection<Autores_Has_Libros>? AutoresHasLibros { get; set; }
    }
}
