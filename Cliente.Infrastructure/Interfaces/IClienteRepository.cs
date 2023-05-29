using Client.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Domain.DTOs;

namespace Client.Infrastructure.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();

        Task<Cliente> GetClientById(Guid id);
        
        Task UpdateCliente(Cliente cliente);

        Task DeleteClienteAsync(Guid id);

        Task CreateCliente(Cliente cliente);

        IEnumerable<Cliente> GetClientesParam(ConsultaCliente consulta);
    }
}
