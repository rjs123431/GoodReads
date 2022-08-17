using GoodReads.Core.Books;

namespace GoodReads.EntityFrameworkCore.Repositories
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAll();
        Task<IQueryable<Book>> GetAllAsync();
        Task<Book> GetAsync(int id);
        Task<int> InsertAndGetIdAsync(Book book);
        Task<Book> UpdateAsync(Book book);
    }
}
