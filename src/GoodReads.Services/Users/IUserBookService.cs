using GoodReads.Services.Users.Dto;

namespace GoodReads.Services.Users
{
    public interface IUserBookService
    {
        Task<IEnumerable<UserBookListDto>> GetAllAsync(GetUserBooksInput input);
        Task AddBookAsync(UserBookDto userBook);
        Task RemoveBookAsync(UserBookDto userBook);
    }
}
