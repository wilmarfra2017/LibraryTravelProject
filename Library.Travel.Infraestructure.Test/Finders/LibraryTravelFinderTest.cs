using Library.Travel.Domain.Aggregates.LibraryTravel.Interfaces;
using Library.Travel.Infraestructure.Finders.LibraryTravel;
using Library.Travel.Transverse.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace Library.Travel.Infraestructure.Test.Finders
{
    public class LibraryTravelFinderTest
    {
        private Mock<ILibraryTravelFinder> _libraryTravelFinderMock;

        private readonly Mock<ILogger<LibraryTravelFinder>> _logger;

        public LibraryTravelFinderTest()
        {
            _libraryTravelFinderMock = new Mock<ILibraryTravelFinder>();
            _logger = new Mock<ILogger<LibraryTravelFinder>>();
        }

        [Fact]
        public void GetAllBooksFinder_WhenRetunDataBooks()
        {
            List<LibroDetalle> bookDetail = new();
            _libraryTravelFinderMock = new();
            _libraryTravelFinderMock.Setup(x => x.GetAllBooksAsync()).Returns(Task.FromResult(bookDetail));

            List<LibroDetalle> bookDetailResult =  _libraryTravelFinderMock.Object.GetAllBooksAsync().Result;            
            Assert.True(bookDetailResult != null);
        }
    }
}
