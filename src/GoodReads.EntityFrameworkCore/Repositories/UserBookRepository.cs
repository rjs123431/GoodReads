using GoodReads.Core.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace GoodReads.EntityFrameworkCore.Repositories
{
    public class UserBookRepository : IUserBookRepository
    {
        private readonly GoodReadsDbContext _context;

        public UserBookRepository(GoodReadsDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(UserBook entity)
        {
            await _context.UserBooks.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(UserBook entity)
        {
            Delete(entity);
            return Task.CompletedTask;
        }

        protected virtual void Delete(UserBook entity)
        {
            AttachIfNot(entity);
            _context.Set<UserBook>().Remove(entity);
            _context.SaveChanges();
        }

        protected virtual void AttachIfNot(UserBook entity)
        {
            var entry = _context.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }

            _context.Set<UserBook>().Attach(entity);
        }

        public async Task<IQueryable<UserBook>> GetAllAsync()
        {
            return await Task.FromResult(_context.UserBooks.Include(x => x.Book));
        }

        public IQueryable<UserBook> GetAll()
        {
            return GetAllIncluding();
        }

        public IQueryable<UserBook> GetAllIncluding(
            params Expression<Func<UserBook, object>>[] propertySelectors)
        {
            var query = GetQueryable();

            if (propertySelectors == null || propertySelectors.Count() <= 0)
            {
                return query;
            }

            foreach (var propertySelector in propertySelectors)
            {
                query = query.Include(propertySelector);
            }

            return query;
        }

        protected IQueryable<UserBook> GetQueryable()
        {
            return _context.UserBooks.AsQueryable();
        }
    }
}
