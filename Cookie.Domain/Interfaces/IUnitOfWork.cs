namespace Cookie.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<bool> Save();
}