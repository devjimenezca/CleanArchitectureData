using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class CuentaRepository : RepositoryBase<Cuenta>, ICuentaRepository
    {
        public CuentaRepository(NttDataDbContext context) : base(context)
        { 
        }
        public async Task<List<CuentaResult>> GetCuentaById(int ClienteId)
        {
            var Cuentas = (from p in _context.Cuenta
                                 join e in _context!.Cliente!
                                 on p.ClienteId equals e.ClienteId
                           join t in _context!.TipoCuenta!
                           on p.TipoCuentaId equals t.TipoCuentaId
                           where p.ClienteId == ClienteId
                           select new CuentaResult()
                                 {
                                     ClienteId = p.CuentaId,
                                     CuentaId = p.CuentaId,
                                     Estado = p.Estado,
                               Cliente = e.Nombre,
                               TipoCuenta = t.Nombre,
                               TipoCuentaId = t.TipoCuentaId,
                               SaldoInicial = p.SaldoInicial
                                 }).ToListAsync();


            return await Cuentas;
        }
    }
}
