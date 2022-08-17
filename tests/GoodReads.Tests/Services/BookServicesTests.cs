using Castle.Core.Resource;
using GoodReads.Core.Books;
using GoodReads.EntityFrameworkCore.Repositories;
using GoodReads.Services.Books;
using GoodReads.Services.Books.Dto;
using Moq;

namespace GoodReads.Tests.Services
{
    public class BookServicesTests : GoodReadsTestBase
    {
        private readonly Mock<IBookRepository> _mockBookRepository;

        public BookServicesTests()
        {
            _mockBookRepository = new Mock<IBookRepository>();
        }

        [Fact]
        public async void Get()
        {
            var bookInMemoryDatabase = new List<Book>
            {
                new Book() { Id = 1, Name = "Book 1" },
                new Book() { Id = 2, Name = "Book 2" },
                new Book() { Id = 3, Name = "Book 3" }
            };

            // Arrange
            _mockBookRepository.Setup(x => x.GetAsync(It.IsAny<int>()))
                .ReturnsAsync((int i) => bookInMemoryDatabase.Single(bo => bo.Id == i));

            var bookService = new BookService(_mockBookRepository.Object);

            // Act
            int bookId = 3;
            var bookFound = await bookService.GetAsync(bookId);

            // Assert
            Assert.NotNull(bookFound);
            Assert.Equal(bookId, bookFound.Id);
        }
    }
}
