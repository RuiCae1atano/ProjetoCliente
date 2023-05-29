using Client.FrontEnd.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.FrontEnd.App.Service
{
    public interface IEnderecoService
    {
        Task<IEnumerable<EstadoViewModel>> GetEstados();
        Task<IEnumerable<CidadeViewModel>> GetCidades();
    }
}
