using Client.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Domain.DTOs
{
    public class ConsultaEstado
    {
        public IEnumerable<EstadoDto> Estados { get; set; }
        public ConsultaEstado() 
        {
            Estados = new List<EstadoDto>();
        }
    }
}
