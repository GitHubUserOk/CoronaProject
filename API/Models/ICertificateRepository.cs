namespace CoronaProject.Models
{
    public interface ICertificateRepository : IDisposable
    {
        Task InsertCertificateAsync(Certificate cert);
        Task SaveAsync();
    }
}
