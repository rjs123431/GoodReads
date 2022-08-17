using GoodReads.Api.Models;
using GoodReads.Services.Users;
using GoodReads.Services.Users.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GoodReads.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBooksController : ControllerBase
    {
        private readonly IUserBookService _userBookService;

        public UserBooksController(IUserBookService userBookService)
        {
            _userBookService = userBookService;
        }

        // GET: api/<UserBooksController>
        [HttpGet("{userId}")]
        public async Task<IEnumerable<UserBookListDto>> Get(int userId)
        {
            var input = new GetUserBooksInput
            {
                UserId = userId
            };

            return await _userBookService.GetAllAsync(input);
        }

        // POST api/<UserBooksController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserBookDto userBook)
        {
            try
            {
                await _userBookService.AddBookAsync(userBook);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponseModel(StatusCodes.Status400BadRequest, ex.Message));
            }
        }

        [HttpDelete]
        public async Task Delete(UserBookDto userBook)
        {
            await _userBookService.RemoveBookAsync(userBook);
        }
    }
}
