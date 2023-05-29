using Client.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Domain.DTOs
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public int IdEstado { get; set; }
        public int IdCidade { get; set; }

        //public ClienteDto(string cpf, string nome, DateTime dataNascimento, string sexo, int estado, int cidade)
        //{
        //    Cpf = cpf;
        //    Nome = nome;
        //    DataNascimento = dataNascimento;
        //    Sexo = sexo;
        //    IdEstado = estado;
        //    IdCidade = cidade;
        //}
    }
}
