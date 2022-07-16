using AutoMapper;
using CleanArchitecture.Application.Features.Clientes;
using CleanArchitecture.Application.Features.Clientes.Queries;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.UnitTests.Mock;
using CleanArchitecture.Infrastructure.Repositories;
using Moq;
using Xunit;
using CleanArchitecture.Application.UnitTest.Mocks;
using Shouldly;

namespace CleanArchitecture.Application.UnitTest.Features.Cliente.Queries
{
    public class GetClienteAllQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetClienteAllQueryHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();


            MockClienteRepository.AddDataClienteRepository(_unitOfWork.Object.ntDataDbContext);

        }

        [Fact]
        public async Task GetClienteListTest()
        {
            var handler = new GetClienteAllQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetClienteAllQuery();

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<ClienteVM>>();

            result!.Count.ShouldBe(4);
        }
    }
}
