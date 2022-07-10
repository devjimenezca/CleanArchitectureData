

using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Persistence;
using System.Collections;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //Coleccion de repositorio
        private Hashtable _repositories;

        private readonly NttDataDbContext _context;
        public NttDataDbContext ntDataDbContext => _context;

        private IClienteRepository _clienteRepository;
        public IClienteRepository ClienteRepository => _clienteRepository ??= new ClienteRepository(_context);


        private ICuentaRepository _cuentaRepository;
        public ICuentaRepository CuentaRepository => _cuentaRepository ??= new CuentaRepository(_context);

        private IMovimientoRepository _movimientoRepository;
        public IMovimientoRepository MovimientoRepository => _movimientoRepository ??= new MovimientoRepository(_context);

        public UnitOfWork(NttDataDbContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            ///throw new NotImplementedException();
        }

        //Instancia de repositorio
        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null) { 
                _repositories = new Hashtable();
            }
            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type)) {

                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)),_context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
