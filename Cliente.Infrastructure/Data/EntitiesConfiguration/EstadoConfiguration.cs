using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Domain.Entities;

namespace Client.Infrastructure.Data.EntitiesConfiguration
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Clientes)
                .WithOne(e => e.Estado)
                .HasForeignKey(e => e.IdEstado).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasMany(e => e.Cidades)
                .WithOne(c => c.Estado)
                .HasForeignKey(c => c.IdEstado).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
