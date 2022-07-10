using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class NttDataDbContext : DbContext
    {
        public NttDataDbContext(DbContextOptions<NttDataDbContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(local); Initial Catalog=NTTDATA; user Id=sa; Password=Manager123")
               .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
               .EnableSensitiveDataLogging();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                { 
                    case EntityState.Added:
                        entry.Entity.CreatedDate =  DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


   


        public DbSet<Cliente>? Cliente { get; set; }

        public DbSet<Cuenta>? Cuenta { get; set; }

        public DbSet<Movimiento>? Movimiento { get; set; }

        public DbSet<TipoCuenta>? TipoCuenta { get; set; }
        public DbSet<TipoMovimiento>? TipoMovimiento { get; set; }

    }
}
