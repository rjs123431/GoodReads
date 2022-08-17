using GoodReads.Services.Books.Dto;

namespace GoodReads.Services.Users.Dto
{
    public class UserBookListDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public BookDto Book { get; set; }
    }
}
