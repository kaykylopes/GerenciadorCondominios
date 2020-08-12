using GerenciadorCondominios.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorCondominios.DAL.Mapeamentos
{
    public class ServicoPrediosMap : IEntityTypeConfiguration<ServicoPredio>
    {
        public void Configure(EntityTypeBuilder<ServicoPredio> builder)
        {
            builder.HasKey(s => s.ServicoPredioId);
            builder.Property(s => s.ServicoId).IsRequired();
            builder.Property(s => s.DataExecucao).IsRequired();

            builder.HasOne(s => s.Servico).WithMany(s => s.ServicoPredios).HasForeignKey(s => s.ServicoId);
            builder.ToTable("ServicoPredios");
        }
    }
}
