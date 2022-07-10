using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Result;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IMovimientoRepository : IAsyncRepository<Movimiento>
    {
        Task<List<MovimientoResult>> GetMovimientoById(int ClienteId);
    }
}
