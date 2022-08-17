using GoodReads.Services.Books;
using GoodReads.Services.Books.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GoodReads.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IEnumerable<BookDto>> Get([FromQuery] GetBooksInput input)
        {
            return await _bookService.GetAllAsync(input);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _bookService.GetAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task Post([FromBody] CreateBookDto book)
        {
            await _bookService.CreateAsync(book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] BookDto book)
        {
            book.Id = id;
            await _bookService.UpdateAsync(book);
        }
    }
}
