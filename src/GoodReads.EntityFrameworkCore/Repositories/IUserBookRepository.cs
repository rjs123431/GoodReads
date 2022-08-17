using GoodReads.Core.Books;
using GoodReads.Core.Users;

namespace GoodReads.EntityFrameworkCore.Repositories
{
    public interface IUserBookRepository
    {
        IQueryable<UserBook> GetAll();
        Task<IQueryable<UserBook>> GetAllAsync();
        Task InsertAsync(UserBook entity);
        Task DeleteAsync(UserBook entity);
    }
}
