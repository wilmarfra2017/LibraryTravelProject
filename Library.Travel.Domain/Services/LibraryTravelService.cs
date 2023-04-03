using Library.Travel.Domain.Aggregates.LibraryTravel.Interfaces;
using Library.Travel.Transverse.Entities;
using Microsoft.Extensions.Logging;

namespace Library.Travel.Domain.Services
{
    public class LibraryTravelService : ILibraryTravelService<LibroDetalle>
    {
        private readonly ILibraryTravelFinder _entityTravelFinder;
        private readonly ILogger<LibraryTravelService> _logger;

        public LibraryTravelService(ILibraryTravelFinder entityTravelFinder, ILogger<LibraryTravelService> logger)
        {
            _entityTravelFinder = entityTravelFinder;
            _logger = logger;
        }


        /// <summary>
        /// Método asíncrono que consulta todos los libros y devuelve la Lista en una clase LibroDetalle
        /// Realiza la consulta llamando al metodo GetAllBooksAsync del finder de la capa de infraestructura
        /// </summary>
        public async Task<List<LibroDetalle>> GetAllBooksAsync()
        {
            _logger.Log(LogLevel.Information, "[Domain/Service] - Class: LibraryTravel - Method: GetAllBooksAsync");

            return await _entityTravelFinder.GetAllBooksAsync();
        }

    }
}
