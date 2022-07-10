using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(NttDataDbContext context) : base(context)
        { }

        public async Task<Cliente> GetClienteByIdent(string identificacion)
        {
            return await _context!.Cliente!.Where(o => o.Identificacion == identificacion).FirstOrDefaultAsync();

        }

        public async Task<List<Cliente>> GetClienteAll()
        {
            return await _context!.Cliente!.ToListAsync();

        }
    }
}
