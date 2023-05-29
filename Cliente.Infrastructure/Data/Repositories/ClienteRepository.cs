using Client.Domain.DTOs;
using Client.Domain.Entities;
using Client.Infrastructure.Data.Context;
using Client.Infrastructure.Helper;
using Client.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ClienteRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await dbContext.Set<Cliente>().ToListAsync();
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            dbContext.Entry(cliente).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(Guid id)
        {
            var cliente = await dbContext.Clientes.FindAsync(id);
            //var clientes = await dbContext.Set<Cliente>().ToListAsync();

            if (cliente != null)
            {
                dbContext.Clientes.Remove(cliente);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task CreateCliente(Cliente cliente)
        {
            dbContext.Set<Cliente>().Add(cliente);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Cliente> GetClientById(Guid id)
        {
            return await dbContext.Clientes.Include(e => e.Estado).FirstOrDefaultAsync(c => c.Id == id);
        }

        public IEnumerable<Cliente> GetClientesParam(ConsultaCliente cliente)
        {
            var query = dbContext.Clientes.AsQueryable();

            if (!string.IsNullOrEmpty(cliente.Cpf))
            {
                query = query.Where(c => c.Cpf == cliente.Cpf);
            }

            if (!string.IsNullOrEmpty(cliente.Nome))
            {
                query = query.Where(c => c.Nome == cliente.Nome);
            }

            if (cliente.DataNascimento.ToString() != "01/01/0001 00:00:00")
            {
                query = query.Where(c => c.DataNascimento == cliente.DataNascimento);
            }

            if (!string.IsNullOrEmpty(cliente.Sexo))
            {
                query = query.Where(c => c.Sexo == cliente.Sexo);
            }

            if (cliente.IdEstado != 0)
            {
                query = query.Where(c => c.IdEstado == cliente.IdEstado);
            }

            if (cliente.IdCidade != 0)
            {
                query = query.Where(c => c.IdCidade == cliente.IdCidade);
            }

                string sqlQuery = query.ToQueryString();
                var resultado = dbContext.Clientes.FromSqlRaw(sqlQuery).ToList();

            return resultado;
        }
    }
}
