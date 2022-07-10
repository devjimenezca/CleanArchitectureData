using CleanArchitecture.Domain.Common;


namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        IClienteRepository ClienteRepository { get; }
        ICuentaRepository CuentaRepository { get; }
        IMovimientoRepository MovimientoRepository { get; }
        Task<int> Complete();
    }
}
