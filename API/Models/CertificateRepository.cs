namespace CoronaProject.Models
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly ApplicationDbContext _context;
        public CertificateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertCertificateAsync(Certificate cert) => await _context.Certificate.AddAsync(cert);

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
