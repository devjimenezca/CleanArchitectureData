using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface ICuentaRepository : IAsyncRepository<Cuenta>
    {
        Task<List<CuentaResult>> GetCuentaById(int ClienteId);
    }
}
