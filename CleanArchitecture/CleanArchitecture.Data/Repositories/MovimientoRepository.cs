using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Result;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class MovimientoRepository : RepositoryBase<Movimiento>, IMovimientoRepository
    {
        public MovimientoRepository(NttDataDbContext context) : base(context)
        { 
        }

        public async Task<List<MovimientoResult>> GetMovimientoById(int ClienteId)
        {
            var Movimientos = (from p in _context.Movimiento
                           join x in _context!.TipoMovimiento!  on p.TipoMovimientoId equals x.TipoMovimientoId
                           join d in _context!.Cuenta!
                           on p.CuentaId equals d.CuentaId
                           join t in _context!.TipoCuenta!
                           on d.TipoCuentaId equals t.TipoCuentaId
                           join c in _context!.Cliente!
                          on d.ClienteId equals c.ClienteId
                           where d.ClienteId == ClienteId
                           select new MovimientoResult()
                           {
                               ClienteId = p.CuentaId,
                               NumeroCuenta = d.NumeroCuenta,   
                               CuentaId = p.CuentaId,
                               Cliente = c.Nombre,
                               TipoCuenta = t.Nombre,
                               TipoCuentaId = t.TipoCuentaId,
                               SaldoInicial = p.SaldoInicial,
                               SaldoDisponible = p.Saldo,
                               Valor = p.Valor,
                               Fecha = p.CreatedDate.ToString(),
                               TipoMovimiento = x.Nombre

                           }).ToListAsync();


            return await Movimientos;
        }

    }
}
