using Client.Domain.DTOs;
using Client.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _service;

        public EnderecoController(IEnderecoService service)
        {
            _service = service;
        }

        [HttpGet("Estados")]
        public async Task<IEnumerable<EstadoDto>> GetEstados() 
        {
            var result = await _service.GetEstados();
            return result;
        }

        [HttpGet("Cidades")]
        public async Task<IEnumerable<CidadeDto>> GetCidades() 
        {
           var result = await _service.GetCidades();
            return result;
        }
    }
}
