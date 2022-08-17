using GoodReads.Api.Controllers;
using GoodReads.Services.Books;
using GoodReads.Services.Books.Dto;
using Moq;

namespace GoodReads.Tests.Controllers
{
    public class BookControllerTests : GoodReadsTestBase
    {
        private readonly Mock<IBookService> _mockBookService;

        public BookControllerTests()
        {
            _mockBookService = new Mock<IBookService>();
        }

        [Fact]
        public async void GetBooks()
        {
            // Arrange
            var input = new GetBooksInput();
            _mockBookService.Setup(service => service.GetAllAsync(input))
                .ReturnsAsync(GetTestBookDtos());
            var controller = new BooksController(_mockBookService.Object);

            // Act
            var books = await controller.Get(input);

            // Assert
            Assert.NotEmpty(books);
        }

        [Fact]
        public async void GetBooksWithCount()
        {
            int maxCount = 8;
            var input = new GetBooksInput()
            {
                MaxResultCount = maxCount
            };

            _mockBookService.Setup(service => service.GetAllAsync(input))
                .ReturnsAsync(GetTestBookDtos().Take(input.MaxResultCount));

            var controller = new BooksController(_mockBookService.Object);

            // Act
            var books = await controller.Get(input);

            // Assert
            Assert.True(books.Count() == maxCount);
        }

        [Fact]
        public async void GetBooksWithFilter()
        {
            string filter = "harry";
            var input = new GetBooksInput()
            {
                Filter = filter
            };

            _mockBookService.Setup(service => service.GetAllAsync(input))
                .ReturnsAsync(GetTestBookDtos().Where(x => x.Name.Contains(input.Filter, StringComparison.InvariantCultureIgnoreCase)).Take(input.MaxResultCount));

            var controller = new BooksController(_mockBookService.Object);

            // Act
            var books = await controller.Get(input);

            // Assert
            Assert.True(books.Count() == 1);
        }
    }
}