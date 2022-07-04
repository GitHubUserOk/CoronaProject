namespace CoronaProject.Models
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly ApplicationDbContext _context;
        public VisitorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertVisitorAsync(Visitor visitor) => await _context.Visitor.AddAsync(visitor);

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
