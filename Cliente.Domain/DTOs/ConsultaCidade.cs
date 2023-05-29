using Client.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Domain.DTOs
{
    public class ConsultaCidade
    {
        public IEnumerable<CidadeDto> Cidades{ get; set; }
        public ConsultaCidade()
        {
            Cidades = new List<CidadeDto>();
        }
    }
}
