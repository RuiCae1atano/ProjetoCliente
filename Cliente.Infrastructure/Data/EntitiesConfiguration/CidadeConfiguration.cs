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
    public class CidadeConfiguration
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Estado)
                .WithMany(e => e.Cidades)
                .HasForeignKey(e => e.IdEstado).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
