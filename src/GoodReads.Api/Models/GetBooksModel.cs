using GoodReads.Services.Books.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GoodReads.Api.Models
{
    public class GetBooksModel
    {
        [FromQuery]
        public GetBooksInput Input { get; set; }
    }
}
