using Library.Travel.Transverse.Entities;

namespace Library.Travel.Domain.Aggregates.LibraryTravel.Interfaces
{
    public interface ILibraryTravelFinder
    {
        public Task<List<LibroDetalle>> GetAllBooksAsync();
    }
}
