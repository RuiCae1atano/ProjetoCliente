using Client.FrontEnd.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.FrontEnd.App.Service
{
    public interface IClientServiceApi
    {
        Task CadastroCliente(ClienteViewModel cliente);

        Task EditaCliente(ClienteViewModel cliente);

        Task<ClienteViewModel> GetClienteById(Guid id);

        Task DeletaCliente(Guid idCliente);

        Task<IEnumerable<ClienteViewModel>> ConsultaCliente(ClienteViewModel cliente);

        Task<IEnumerable<ClienteViewModel>> ObterClientes();
    }
}
