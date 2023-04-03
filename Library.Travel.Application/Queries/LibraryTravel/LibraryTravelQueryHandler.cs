using Library.Travel.Domain.Aggregates.LibraryTravel.Interfaces;
using Library.Travel.Transverse.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Travel.Application.Queries.LibraryTravel
{
    /// <summary>    
    /// Se implementa la interfaz IRequestHandler para manejar la solicitud y la respuesta de las consulta.
    /// </summary>
    public class LibraryTravelQueryHandler : IRequestHandler<LibraryTravelQueryRequest, LibraryTravelQueryResponse>
    {
        private readonly ILibraryTravelService<LibroDetalle> _libraryTravelService;
        private readonly ILogger<LibraryTravelQueryHandler> _logger;

        public LibraryTravelQueryHandler(ILibraryTravelService<LibroDetalle> libraryTravelService, ILogger<LibraryTravelQueryHandler> logger)
        {
            _libraryTravelService = libraryTravelService;
            _logger = logger;
        }


        /// <summary>
        /// Método asíncrono que maneja la solicitud de consulta, obtiene todos los libros y devuelve la respuesta.
        /// Realiza la consulta llamando al metodo GetAllBooksAsync del servicio de la capa de dominio
        /// </summary>
        public async Task<LibraryTravelQueryResponse> Handle(LibraryTravelQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.Log(LogLevel.Information, "[Application/Handler] - Class: LibraryTravelQueryHandler");

            List<LibroDetalle> libroDetalles = await _libraryTravelService.GetAllBooksAsync();
            return new LibraryTravelQueryResponse(libroDetalles);
        }
    }
}
