namespace Library.Travel.Transverse.Entities
{
    public class Editorial
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Sede { get; set; } = string.Empty;

        public ICollection<Libro>? Libros { get; set; }
    }
}
