using GoodReads.Core.Books;
using GoodReads.EntityFrameworkCore.Extensions;
using GoodReads.EntityFrameworkCore.Repositories;
using GoodReads.Services.Books.Dto;
using System.Linq.Dynamic.Core;

namespace GoodReads.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> CreateAsync(CreateBookDto book)
        {
            var entity = MapToEntity(book);
            var id = await _bookRepository.InsertAndGetIdAsync(entity);

            return id;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync(GetBooksInput input)
        {
            var query = _bookRepository.GetAll();

            if (!string.IsNullOrEmpty(input.Filter))
            {
                query = query.Where(x => x.Name.Contains(input.Filter));
            }

            var count = query.Count();

            var data = await query
                .OrderBy(input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();

            var result = data.Select(b => MapToDto(b)).ToList();

            return result;

        }

        public async Task<BookDto> GetAsync(int id)
        {
            var entity = await _bookRepository.GetAsync(id);

            var result = MapToDto(entity);

            return result;
        }

        public async Task UpdateAsync(BookDto book)
        {
            var entity = MapToEntity(book);

            await _bookRepository.UpdateAsync(entity);
        }

        private BookDto MapToDto(Book entity)
        {
            if (entity == null)
                return null;

            return new BookDto()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        private Book MapToEntity(BookDto dto)
        {
            return new Book()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        private Book MapToEntity(CreateBookDto dto)
        {
            return new Book()
            {
                Name = dto.Name
            };
        }
    }
}