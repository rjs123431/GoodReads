using GoodReads.Core.Books;
using GoodReads.Services.Dtos;

namespace GoodReads.Services.Books.Dto
{
    public class GetBooksInput : PagedResultFilterRequestDto
    {
        public GetBooksInput()
        {
            Sorting = nameof(Book.Name);
        }
    }
}
