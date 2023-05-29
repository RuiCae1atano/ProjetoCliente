using Client.Domain.DTOs;
using Client.Services;
using Client.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService service)
        {
            _clienteService = service;
        }

        [HttpPost]
        public async Task<IActionResult> CadastroCliente(ClienteDto cliente)
        {
            await _clienteService.CadastroCliente(cliente);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditaCliente(ClienteDto resultadoConsulta)
        {
            await _clienteService.EditaCliente(resultadoConsulta);

            return Ok();
        }

        [HttpDelete("{idCliente}")]
        public async Task<IActionResult> DeletaCliente(Guid idCliente)
        {
            await _clienteService.DeletaCliente(idCliente);
            //if (deletedRows == 0)
            //{
            //    return NotFound();
            //}

            return Ok();
        }

        [HttpPost("ConsultaCliente")]
        public async Task<IActionResult> ConsultaCliente( ConsultaCliente cliente)
        {
            var resultado = await _clienteService.ConsultaCliente(cliente);
            return Ok(resultado);
        }

        [HttpGet("GetClienteById")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            var resultado = await _clienteService.GetClienteById(id);
            return Ok(resultado);
        }

        [HttpGet("GetAllClientes")]
        public async Task<IActionResult> GetAllClientes()
        {
            var resultado = await _clienteService.GetAllClientes();
            return Ok(resultado);
        }
    }
}
