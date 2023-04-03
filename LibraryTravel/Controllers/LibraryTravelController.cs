using Library.Travel.Application.Queries.LibraryTravel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Travel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LibraryTravelController : Controller
    {
        /// <summary>
        /// En este controller se usa una instancia de IMediator utilizada para la comunicación entre objetos e instancia de ILogger para usar log de información.        
        /// </summary>
        private readonly IMediator _mediator;
        private readonly ILogger<LibraryTravelController> _logger;


        // <summary>
        /// Se usa principio de inversión de dependencia (DIP), tambien llamado inyección de dependencias        
        /// </summary>
        public LibraryTravelController(IMediator mediator, ILogger<LibraryTravelController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        /// <summary>
        /// Realiza una búsqueda de detalles de libros utilizando una consulta a través del mediador y devuelve la lista de libros obtenida.
        /// </summary>
        /// <returns>
        /// Retorna un objeto LibraryTravelQueryResponse que contiene la lista de detalles de los libros.
        /// </returns>         
        [HttpGet]
        public async Task<LibraryTravelQueryResponse> FindBooksDetail()
        {
            _logger.Log(LogLevel.Information, "[Api/Controller] - Class: LibraryTravelController - Method: FindBooksDetail");
            
            LibraryTravelQueryResponse? listBooks = await _mediator.Send(new LibraryTravelQueryRequest());

            if(listBooks == null) { throw new Exception("Book list not found"); }
           
            return (LibraryTravelQueryResponse)listBooks;            
        }

    }
}
