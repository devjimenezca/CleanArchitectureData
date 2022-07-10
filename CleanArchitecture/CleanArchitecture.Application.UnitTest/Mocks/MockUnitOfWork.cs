using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.UnitTests.Mock
{
    public static class MockUnitOfWork
    {
       

        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<NttDataDbContext>()
                .UseInMemoryDatabase(databaseName: $"NttDataDbContext-{dbContextId}")
                .Options;

            var nttdataDbContextFake = new NttDataDbContext(options);
            nttdataDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(nttdataDbContextFake);
                    

            return mockUnitOfWork;
        }

    }
}
