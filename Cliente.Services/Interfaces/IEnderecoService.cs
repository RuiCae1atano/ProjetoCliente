using Client.Domain.DTOs;
using Client.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task<IEnumerable<EstadoDto>> GetEstados();
        Task<IEnumerable<CidadeDto>> GetCidades();
    }
}
