using GoodReads.Core.Users;

namespace GoodReads.EntityFrameworkCore.Repositories
{
    public interface IUserRepository
    {
        Task<IQueryable<User>> GetAllAsync();
        Task<User> GetAsync(int id);
        Task<int> InsertAndGetIdAsync(User book);
        Task<User> UpdateAsync(User book);
    }
}
