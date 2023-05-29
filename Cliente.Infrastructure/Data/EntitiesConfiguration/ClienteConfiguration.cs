using Client.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure.Data.EntitiesConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome);
            builder.Property(x => x.Sexo);
            builder.HasOne(x => x.Estado).WithMany(e => e.Clientes).HasForeignKey(e => e.IdEstado).OnDelete(DeleteBehavior.NoAction); ;
            builder.HasOne(x => x.Cidade).WithMany(c => c.Clientes).HasForeignKey(c => c.IdCidade).OnDelete(DeleteBehavior.NoAction); ;
            builder.Property(x => x.DataNascimento);
        }
    }
}
