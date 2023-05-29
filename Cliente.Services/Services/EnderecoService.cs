using AutoMapper;
using Client.Domain.DTOs;
using Client.Domain.Entities;
using Client.Infrastructure.Interfaces;
using Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EstadoDto>> GetEstados()
        {

            var result = _mapper.Map<IEnumerable<EstadoDto>>(await _enderecoRepository.GetEstado());
            return result;
        }

        public async Task<IEnumerable<CidadeDto>> GetCidades()
        {
            var result = _mapper.Map<IEnumerable<CidadeDto>>(await _enderecoRepository.GetCidades());
            return result;
        }
    }
}
