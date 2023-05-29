using Client.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure.Interfaces
{
    public interface IEnderecoRepository
    {
        Task <IEnumerable<Estado>> GetEstado();

        Task<IEnumerable<Cidade>> GetCidades();
    }
}
