using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }

        public Estado Estado { get; set; }
        public Cidade Cidade { get; set; }


        public int IdEstado { get; set; }

        [Column("IdCidade")]
        public int IdCidade { get; set; }
    }
}
