
namespace Client.FrontEnd.App.Models
{
    public class CidadeViewModel
    {
        public int Id { get; set; }

        public string NomeCidade { get; set; }
        public int IdEstado { get; set; }
        public EstadoViewModel Estado { get; set; }
    }
}