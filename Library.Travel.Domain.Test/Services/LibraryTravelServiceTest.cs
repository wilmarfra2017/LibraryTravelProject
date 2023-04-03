using Library.Travel.Domain.Aggregates.LibraryTravel.Interfaces;
using Library.Travel.Domain.Services;
using Library.Travel.Transverse.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace Library.Travel.Domain.Test.Services
{
    public class LibraryTravelServiceTest
    {
        private readonly Mock<ILibraryTravelFinder> _libraryTravelFinderMock;

        private readonly Mock<ILogger<LibraryTravelService>> _logger;

        public LibraryTravelServiceTest()
        {
            _libraryTravelFinderMock = new Mock<ILibraryTravelFinder>();
            _logger = new Mock<ILogger<LibraryTravelService>>();
        }

        [Fact]
        public async Task GetAllBooksAsync_WhenRetunDataBooks()
        {
            //Arrange
            var libraryTravel = new LibroDetalle();

            var list = new List<LibroDetalle>();
            list.Add(libraryTravel);
            list.Add(libraryTravel);
            list.Add(libraryTravel);

            _libraryTravelFinderMock
                .Setup(s => s.GetAllBooksAsync())
                .ReturnsAsync(list)
                .Verifiable();

            var libraryTravelService = new LibraryTravelService(_libraryTravelFinderMock.Object, _logger.Object);

            //Act
            var libraryTravelResult = await libraryTravelService.GetAllBooksAsync();

            //Assert
            Assert.NotNull(libraryTravelResult);
            Assert.True(libraryTravelResult.Any());
            _libraryTravelFinderMock.VerifyAll();
        }

    }
}
