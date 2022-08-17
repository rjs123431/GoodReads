using GoodReads.Core.Users;
using GoodReads.EntityFrameworkCore.Repositories;
using GoodReads.Services.Books.Dto;
using GoodReads.Services.Users.Dto;

namespace GoodReads.Services.Users
{
    public class UserBookService : IUserBookService
    {
        private readonly IUserBookRepository _userBookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;

        public UserBookService(IUserBookRepository userBookRepository
            , IUserRepository userRepository
            , IBookRepository bookRepository)
        {
            _userBookRepository = userBookRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public async Task AddBookAsync(UserBookDto userBook)
        {
            // validate
            var user = await _userRepository.GetAsync(userBook.UserId);
            if (user == null)
                throw new Exception("User not found.");

            var book = await _bookRepository.GetAsync(userBook.BookId);
            if (book == null)
                throw new Exception("Book not found.");

            var userBooks = await _userBookRepository.GetAllAsync();

            var found = userBooks.Where(x => x.UserId == userBook.UserId && x.BookId == userBook.BookId).ToList();
            if (found.Any())
                throw new Exception("Book is already added to the user.");

            var entity = MapToEntity(userBook);

            await _userBookRepository.InsertAsync(entity);
        }

        public async Task<IEnumerable<UserBookListDto>> GetAllAsync(GetUserBooksInput input)
        {
            var userBooks = await _userBookRepository.GetAllAsync();

            userBooks.Where(x => x.UserId == input.UserId);

            var data = userBooks.ToList();

            var result = data.Select(b => MapToListDto(b)).ToList();

            return result;
        }

        public async Task RemoveBookAsync(UserBookDto userBook)
        {
            var entity = MapToEntity(userBook);

            await _userBookRepository.DeleteAsync(entity);
        }

        private UserBookListDto MapToListDto(UserBook userBook)
        {
            return new UserBookListDto
            {
               UserId  = userBook.UserId,
               BookId = userBook.BookId,
               Book = new BookDto
               {
                   Id = userBook.Book.Id,
                   Name = userBook.Book.Name
               }
            };
        }

        private UserBook MapToEntity(UserBookDto userBook)
        {
            return new UserBook
            {
                UserId = userBook.UserId,
                BookId = userBook.BookId
            };
        }
    }
}
