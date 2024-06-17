using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.TorneSeUmProgramador.Core.Modelos;

namespace Todo.TorneSeUmProgramador.Data.Mapeamentos;

public class TarefaMapemento : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.ToTable("Tarefas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion<string>();

        builder.Property(x => x.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.DataConclusao)
            .IsRequired();

        builder.Property(x => x.Concluida)
            .IsRequired();
    }
}
