using GoodReads.Core.Books;

namespace GoodReads.EntityFrameworkCore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly GoodReadsDbContext _context;

        public BookRepository(GoodReadsDbContext context)
            => _context = context;

        public async Task<int> InsertAndGetIdAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task<IQueryable<Book>> GetAllAsync()
        {
            return await Task.FromResult(_context.Books);
        }

        public async Task<Book> GetAsync(int id)
        {
            return await Task.FromResult(_context.Books.FirstOrDefault(x => x.Id == id));
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            return await Task.FromResult(Update(book));
        }

        protected virtual Book Update(Book book)
        {
            AttachIfNot(book);
            _context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return book;
        }

        protected virtual void AttachIfNot(Book entity)
        {
            var entry = _context.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }

            _context.Set<Book>().Attach(entity);
        }

        public IQueryable<Book> GetAll()
        {
            return _context.Books;
        }
    }
}