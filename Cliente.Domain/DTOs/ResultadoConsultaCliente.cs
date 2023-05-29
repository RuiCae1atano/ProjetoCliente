using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Domain.DTOs
{
    public class ResultadoConsultaCliente
    {
        public Guid Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

        public ResultadoConsultaCliente(Guid id, string cpf, string nome, DateTime dataNascimento, string sexo, string estado, string cidade)
        {
            Id = id;
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Estado = estado;
            Cidade = cidade;
        }
    }
}
