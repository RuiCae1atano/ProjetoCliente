using Client.Domain.Entities;
using Client.Infrastructure.Data.Context;
using Client.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public EnderecoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Cidade>> GetCidades()
        {
            return await _dbContext.Set<Cidade>().ToListAsync();
        }

        public async Task<IEnumerable<Estado>> GetEstado()
        {
            return await _dbContext.Set<Estado>().ToListAsync();
        }
    }
}
