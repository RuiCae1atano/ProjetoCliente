using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Domain.DTOs
{
    public class ConsultaCliente
    {
        public string? Cpf { get; set; } = string.Empty;
        public string? Nome { get; set; } = string.Empty;
        public DateTime? DataNascimento { get; set; } = DateTime.MinValue;
        public string? Sexo { get; set; }
        public int IdEstado { get; set; } = 0;
        public int IdCidade { get; set; } = 0;
    }
}
