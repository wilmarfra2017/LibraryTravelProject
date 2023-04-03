using Library.Travel.Api.Controllers;
using Library.Travel.Application.Queries.LibraryTravel;
using Library.Travel.Transverse.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;

namespace Library.Travel.Api.Test
{
    public class LibraryTravelControllerTest
    {
        private readonly Mock<IMediator> _imediator;
        private readonly LibraryTravelController _controller;

        public LibraryTravelControllerTest()
        {
            _imediator = new Mock<IMediator>();
            var logger = new Mock<ILogger<LibraryTravelController>>();

            //Arrange
            _controller = new LibraryTravelController(_imediator.Object, logger.Object);
        }

        [Fact]
        private void FindBooksDetail_Controller_ReturnsSuccess()
        {
            //Arrange
            var booksDetail = new LibroDetalle();

            var list = new List<LibroDetalle>();
            list.Add(booksDetail);
            list.Add(booksDetail);
            list.Add(booksDetail);
            IList<LibroDetalle> wm = list.ToList();

            var response = new LibraryTravelQueryResponse(wm);
            _imediator
                .Setup(s => s.Send(new LibraryTravelQueryResponse(), new CancellationToken()))
                .ReturnsAsync(response)
                .Verifiable();

            //Act
            var result = _controller.FindBooksDetail();
            //Assert
            Assert.NotNull(result);

        }
    }
}
