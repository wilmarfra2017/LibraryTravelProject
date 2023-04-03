using Library.Travel.Application.Queries.LibraryTravel;
using Library.Travel.Domain.Aggregates.LibraryTravel.Interfaces;
using Library.Travel.Transverse.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace Library.Travel.Application.Test
{
    public class LibraryTravelQueryHandlerTest
    {
        private readonly Mock<ILibraryTravelService<LibroDetalle>> _libraryTravelServiceMock;

        private readonly Mock<ILogger<LibraryTravelQueryHandler>> _logger;

        public LibraryTravelQueryHandlerTest()
        {
            _libraryTravelServiceMock = new Mock<ILibraryTravelService<LibroDetalle>>();
            _logger = new Mock<ILogger<LibraryTravelQueryHandler>>();
        }

        [Fact]
        public async Task Select_LibraryTravelQueryRequest_LibraryTravelQueryResponse()
        {
            //Arrange

            var request = new LibraryTravelQueryRequest();
            var libraryTravel = new LibroDetalle();
            var list = new List<LibroDetalle>
            {
               libraryTravel,
               libraryTravel,
               libraryTravel
            };
            _libraryTravelServiceMock
                .Setup(s => s.GetAllBooksAsync())
                .ReturnsAsync(list)
                .Verifiable();

            var service = new LibraryTravelQueryHandler(_libraryTravelServiceMock.Object, _logger.Object);

            //Act
            var libraryTravelQueryResponse = await service.Handle(request, new CancellationToken());

            //Assert
            libraryTravelQueryResponse.Equals(true);
        }

    }
}