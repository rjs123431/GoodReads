using GoodReads.Core.Users;
using GoodReads.EntityFrameworkCore.Repositories;
using GoodReads.Services.Users.Dto;

namespace GoodReads.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> CreateAsync(CreateUserDto User)
        {
            var entity = MapToEntity(User);
            var id = await _userRepository.InsertAndGetIdAsync(entity);

            return id;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            var result = users.ToList().Select(b => MapToDto(b)).ToList();

            return result;

        }

        public async Task<UserDto> GetAsync(int id)
        {
            var entity = await _userRepository.GetAsync(id);

            var result = MapToDto(entity);

            return result;
        }

        public async Task UpdateAsync(UserDto User)
        {
            var entity = MapToEntity(User);

            await _userRepository.UpdateAsync(entity);
        }

        private UserDto MapToDto(User entity)
        {
            return new UserDto()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        private User MapToEntity(UserDto dto)
        {
            return new User()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        private User MapToEntity(CreateUserDto dto)
        {
            return new User()
            {
                Name = dto.Name
            };
        }
    }
}