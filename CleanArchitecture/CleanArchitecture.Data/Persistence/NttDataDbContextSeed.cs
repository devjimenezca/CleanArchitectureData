using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class NttDataDbContextSeed
    {
        public static async Task SeedAsync(NttDataDbContext context, ILogger<NttDataDbContextSeed> logger)
        {
            if (!context.TipoCuenta!.Any())
            {
                context.TipoCuenta!.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(NttDataDbContext).Name);
            }
        
        }

        private static IEnumerable<TipoCuenta> GetPreconfiguredStreamer()
        {
            return new List<TipoCuenta>
            {
                new TipoCuenta {CreatedBy = "System", Nombre = "Ahorro", Estado = 1 },
                new TipoCuenta {CreatedBy = "System", Nombre = "Corriente", Estado = 1 },
            };
        
        }


    }
}
