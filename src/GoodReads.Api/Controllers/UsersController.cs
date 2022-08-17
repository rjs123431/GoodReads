using GoodReads.Services.Users;
using GoodReads.Services.Users.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GoodReads.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            return await _userService.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<UserDto> Get(int id)
        {
            return await _userService.GetAsync(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task Post([FromBody] CreateUserDto User)
        {
            await _userService.CreateAsync(User);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] UserDto User)
        {
            User.Id = id;
            await _userService.UpdateAsync(User);
        }
    }
}
