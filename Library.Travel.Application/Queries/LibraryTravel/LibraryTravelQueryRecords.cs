using Library.Travel.Transverse.Entities;
using MediatR;

/// <summary>
/// Representa una solicitud de consulta de libros, por medio del Patron CQRS
/// Implementa la interfaz IRequest para permitir su uso con la libreria MediatR.
/// </summary>
namespace Library.Travel.Application.Queries.LibraryTravel
{
    public readonly record struct LibraryTravelQueryRequest : IRequest<LibraryTravelQueryResponse>;

    public readonly record struct LibraryTravelQueryResponse(IList<LibroDetalle>? DetailBooks);

}
