using GoodReads.Core.Users;

namespace GoodReads.EntityFrameworkCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GoodReadsDbContext _context;

        public UserRepository(GoodReadsDbContext context)
            => _context = context;

        public async Task<int> InsertAndGetIdAsync(User User)
        {
            await _context.Users.AddAsync(User);
            await _context.SaveChangesAsync();

            return User.Id;
        }

        public async Task<IQueryable<User>> GetAllAsync()
        {
            return await Task.FromResult(_context.Users);
        }

        public async Task<User> GetAsync(int id)
        {
            return await Task.FromResult(_context.Users.FirstOrDefault(x => x.Id == id));
        }

        public async Task<User> UpdateAsync(User User)
        {
            return await Task.FromResult(Update(User));
        }

        protected virtual User Update(User User)
        {
            AttachIfNot(User);
            _context.Entry(User).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return User;
        }

        protected virtual void AttachIfNot(User entity)
        {
            var entry = _context.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }

            _context.Set<User>().Attach(entity);
        }
    }
}