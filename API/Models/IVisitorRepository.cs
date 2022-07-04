namespace CoronaProject.Models
{
    public interface IVisitorRepository : IDisposable
    {
        Task InsertVisitorAsync(Visitor visitor);
        Task SaveAsync();
    }
}
