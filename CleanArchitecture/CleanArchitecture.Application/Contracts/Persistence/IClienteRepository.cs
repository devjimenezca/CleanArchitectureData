using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IClienteRepository : IAsyncRepository<Cliente>
    {
        Task<Cliente> GetClienteByIdent(string identificacion);
        Task<List<Cliente>> GetClienteAll();
    }
}
