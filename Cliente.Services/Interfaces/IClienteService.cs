using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Domain.Entities;
using Client.Domain.DTOs;

namespace Client.Services.Interfaces
{
    public interface IClienteService
    {
        Task CadastroCliente(ClienteDto cliente);

        Task EditaCliente(ClienteDto resultadoConsulta);

        Task DeletaCliente(Guid idCliente);

        Task<ClienteDto> GetClienteById(Guid idCliente);

        Task<IEnumerable<ClienteDto>> ConsultaCliente(ConsultaCliente cliente);
        Task<IEnumerable<ClienteDto>> GetAllClientes();
    }
}
