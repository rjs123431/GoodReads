using GoodReads.Services.Books.Dto;
using GoodReads.Services.Users.Dto;

namespace GoodReads.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetAsync(int id);
        Task<int> CreateAsync(CreateUserDto book);
        Task UpdateAsync(UserDto book);
    }
}
