using Client.FrontEnd.App.Models;
using Client.FrontEnd.App.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Client.FrontEnd.App.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClientServiceApi _service;

        public ClienteController(ILogger<ClienteController> logger, IClientServiceApi service)
        {
            _logger = logger;
            _service = service;        }

        #region Listagem-Index-Cliente
        public IActionResult Index()
        {
            //Apresentar os clientes em um data table
            //Apresentar 

            return View();
        }

        [HttpGet]
        public IActionResult ObterClientes()
        {
            var clientes =  _service.ObterClientes().Result;
            return Json(clientes);
        }

        #endregion

        #region Criar Cliente
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult CriarCliente([FromBody] ClienteViewModel cliente)
        {

            if (cliente == null)
            {
                return BadRequest();
            }

            var clientes = _service.CadastroCliente(cliente);
            var message = new MessageViewModel("Cliente criado com sucesso.");
            if (clientes.IsCompletedSuccessfully == true)
            {
                return Json(message);
            }
            return BadRequest();
        }
        #endregion

        #region DeletarCliente
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult DeleteCliente(Guid id)
        {


            if (id == null)
            {
                return BadRequest();
            }
            _service.DeletaCliente(id);
            var message = new MessageViewModel("Cliente deletado com sucesso.");
            return Ok(message);
        }
        #endregion

        #region AtualizarCliente

        public IActionResult Update(Guid id)
        {
            var result = _service.GetClienteById(id).Result;
            return View(result);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetClienteById(Guid id)
        {
            var result = _service.GetClienteById(id).Result;
            return Json(result);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult UpdateCliente(ClienteViewModel cliente)
        {


            if (cliente == null)
            {
                return BadRequest();
            }
            _service.EditaCliente(cliente);
            var message = new MessageViewModel("Cliente atualizado com sucesso.");
            return Json(message);
        }

        #endregion

        #region PesquisarCliente
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult SearchCliente([FromBody] ClienteViewModel cliente)
        {


            if (cliente == null)
            {
                return BadRequest();
            }

            //mapear cliente
            var clientes = _service.ConsultaCliente(cliente).Result;
            return Json(clientes);
        }

        #endregion
    }
}
