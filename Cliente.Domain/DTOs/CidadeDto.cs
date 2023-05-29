using Client.Domain.Entities;

namespace Client.Domain.DTOs
{
    public class CidadeDto
    {
        public int Id { get; set; }

        public string NomeCidade { get; set; }
        public int IdEstado { get; set; }
        public Estado Estado { get; set; }
    }
}