using CleanArchitecture.Application.Contracts.Persistence;
using Moq;
using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Application.UnitTest.Mocks
{
    public static class MockClienteRepository
    {
        public static void AddDataClienteRepository(NttDataDbContext nttDataDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var cliente = fixture.CreateMany<Cliente>().ToList();

            cliente.Add(fixture.Build<Cliente>()
                .With(tr => tr.CreatedBy, "system")
                .Create()
            );

            nttDataDbContextFake.Cliente!.AddRange(cliente);
            nttDataDbContextFake.SaveChanges();
        }
    }
}
