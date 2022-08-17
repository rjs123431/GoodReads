using GoodReads.Core.Books;
using GoodReads.Services.Books.Dto;

namespace GoodReads.Tests
{
    public abstract class GoodReadsTestBase
    {
        protected static List<BookDto> GetTestBookDtos()
        {
            var books = new List<BookDto>
            {
                new BookDto()
                {
                    Id = 1,
                    Name = "Book 1"
                },
                new BookDto()
                {
                    Id = 2,
                    Name = "Book 2"
                },
                new BookDto()
                {
                    Id = 3,
                    Name = "Book 3"
                },
                new BookDto()
                {
                    Id = 4,
                    Name = "Book 4"
                },
                new BookDto()
                {
                    Id = 5,
                    Name = "Harry Potter"
                },
                new BookDto()
                {
                    Id = 6,
                    Name = "Book 6"
                },
                new BookDto()
                {
                    Id = 7,
                    Name = "Book 7"
                },
                new BookDto()
                {
                    Id = 8,
                    Name = "Book 8"
                },
                new BookDto()
                {
                    Id = 9,
                    Name = "Book 9"
                },
                new BookDto()
                {
                    Id = 10,
                    Name = "Book 10"
                },
                new BookDto()
                {
                    Id = 11,
                    Name = "Book 11"
                },
                new BookDto()
                {
                    Id = 12,
                    Name = "Book 12"
                }
            };
            return books;
        }
    }
}
