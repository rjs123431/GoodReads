using GoodReads.Services.Books.Dto;

namespace GoodReads.Services.Books
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllAsync(GetBooksInput input);
        Task<BookDto> GetAsync(int id);
        Task<int> CreateAsync(CreateBookDto book);
        Task UpdateAsync(BookDto book);
    }
}
