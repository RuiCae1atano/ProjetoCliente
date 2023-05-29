using Client.Domain.Entities;
using Client.Infrastructure.Interfaces;
using Client.Domain.DTOs;
using Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections;

namespace Client.Services.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task CadastroCliente(ClienteDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            await _clienteRepository.CreateCliente(cliente);
        }

        public async Task<IEnumerable<ClienteDto>> ConsultaCliente(ConsultaCliente cliente)
        {
            var result = await Task.FromResult(_clienteRepository.GetClientesParam(cliente));
            var listaCliente = _mapper.Map<IEnumerable<ClienteDto>>(result);
            return listaCliente;
        }

        public async Task DeletaCliente(Guid idCliente)
        {            
            await _clienteRepository.DeleteClienteAsync(idCliente);
        }

        public async Task EditaCliente(ClienteDto resultadoConsulta)
        {
            var cliente = _mapper.Map<Cliente>(resultadoConsulta);
            await _clienteRepository.UpdateCliente(cliente);
        }

        public async Task<IEnumerable<ClienteDto>> GetAllClientes()
        {
            var resultado = await _clienteRepository.GetClientesAsync();
            var listaCliente = _mapper.Map<IEnumerable<ClienteDto>>(resultado);
            return listaCliente;
        }

        public async Task<ClienteDto> GetClienteById(Guid id)
        {

            var cliente = _mapper.Map<ClienteDto>(await _clienteRepository.GetClientById(id));

            return cliente;
        }
    }
}
