using System;

namespace Client.FrontEnd.App.Models
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public int IdEstado { get; set; }
        public int IdCidade { get; set; }
    }
}
