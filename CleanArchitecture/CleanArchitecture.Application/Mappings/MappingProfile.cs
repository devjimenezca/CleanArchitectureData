using AutoMapper;
using CleanArchitecture.Application.Features.Clientes;
using CleanArchitecture.Application.Features.Clientes.Commands;
using CleanArchitecture.Application.Features.Clientes.Commands.UpdateCliente;
using CleanArchitecture.Application.Features.Cuentas;
using CleanArchitecture.Application.Features.Cuentas.Commands;
using CleanArchitecture.Application.Features.Cuentas.Commands.UpdateCuenta;
using CleanArchitecture.Application.Features.Movimientos;
using CleanArchitecture.Application.Features.Movimientos.Commands;
using CleanArchitecture.Application.Features.Movimientos.Commands.UpdateMovimiento;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Result;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteVM>();
            CreateMap<CuentaResult, CuentaVM>();
            CreateMap<MovimientoResult, MovimientoVM>();
            CreateMap<CreateClienteCommand, Cliente>();
            CreateMap<UpdateClienteCommand, Cliente>();
            CreateMap<CreateCuentaCommand, Cuenta>();
            CreateMap<UpdateCuentaCommand, Cuenta>();
            CreateMap<CreateMovimientoCommand, Movimiento>();
            CreateMap<UpdateMovimientoCommand, Movimiento>();
        }
    }
}
