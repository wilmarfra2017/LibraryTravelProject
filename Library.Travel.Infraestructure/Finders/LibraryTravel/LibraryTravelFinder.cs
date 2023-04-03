#nullable disable
using Library.Travel.Domain.Aggregates.LibraryTravel.Interfaces;
using Library.Travel.Transverse.Entities;
using Library.Travel.Transverse.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Library.Travel.Infraestructure.Finders.LibraryTravel
{
    
    public class LibraryTravelFinder : ILibraryTravelFinder
    {

        private readonly SqlServerDbContext _dbContext;
        private readonly ILogger<LibraryTravelFinder> _logger;

        public LibraryTravelFinder(SqlServerDbContext dbContext, ILogger<LibraryTravelFinder> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Método asíncrono para persistencia, la función es consultar todos los libros y devuelve la Lista en una clase LibroDetalle
        /// Realiza la consulta a Base de Datos SQL por medio de EntityFrameworkCore
        /// </summary>
        public async Task<List<LibroDetalle>> GetAllBooksAsync()
        {
            _logger.Log(LogLevel.Information, "[Infraestructure/Finder] - Class: LibraryTravelFinder - Method: GetAllBooksAsync");
            List<LibroDetalle> libroDetalles;

            try
            {
                libroDetalles = await _dbContext.Libros
                    .Include(libro => libro.Editorial)
                    .Include(libro => libro.Autores_Has_Libros)
                        .ThenInclude(autoresHasLibros => autoresHasLibros.Autor)
                    .Select(libro => new
                    {
                        Libro = libro,
                        Autor = libro.Autores_Has_Libros.Select(autoresHasLibros => autoresHasLibros.Autor).DefaultIfEmpty().FirstOrDefault()
                    })
                    .ToListAsync()
                    .ContinueWith(task =>
                        task.Result.Select(result => new LibroDetalle
                        {
                            ISBN = result.Libro.ISBN,
                            Titulo = result.Libro.Titulo,
                            AutorNombre = result.Autor?.Nombre ?? string.Empty,
                            AutorApellidos = result.Autor?.Apellidos ?? string.Empty,
                            EditorialNombre = result.Libro.Editorial?.Nombre ?? string.Empty,
                            EditorialSede = result.Libro.Editorial?.Sede ?? string.Empty,
                            Sinopsis = result.Libro.Sinopsis,
                            NPaginas = result.Libro.N_Paginas
                        }).ToList()
                    );
            }
            catch (Exception ex)
            {
                LogUtils.WriteErrorLog("[Infraestructure/Finder] - Method: GetAllBooksAsync - Error: ", ex);
                throw;
            }
            return libroDetalles;
        }
    }
}
