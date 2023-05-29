using Client.FrontEnd.App.Models;
using Client.FrontEnd.App.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.FrontEnd.App.Controllers
{
    public class EnderecoController
    {
        private readonly IEnderecoService _service;

        public EnderecoController(IEnderecoService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<EstadoViewModel>> GetEstados()
        {
            var result = await _service.GetEstados();
            return result;
        }

        public async Task<IEnumerable<CidadeViewModel>> GetCidades()
        {
            var result = await _service.GetCidades();
            return result;
        }
    }
}
