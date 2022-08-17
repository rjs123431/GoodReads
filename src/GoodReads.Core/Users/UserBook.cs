using GoodReads.Core.Books;

namespace GoodReads.Core.Users
{
    public class UserBook
    {
        public int UserId { get; set; }
        public int BookId { get; set; }

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
