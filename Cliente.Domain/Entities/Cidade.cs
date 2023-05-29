using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Domain.Entities
{
    public class Cidade
    {
        [Column("Id")]
        public int Id { get; set; }
        public List<Cliente> Clientes { get; set; }

        public string NomeCidade { get; set; }
        public int IdEstado { get; set; }
        public Estado Estado { get; set; }

        //public List<Cliente>  Clientes { get; set; }
        //public Guid IdCliente { get; set; }
    }
}