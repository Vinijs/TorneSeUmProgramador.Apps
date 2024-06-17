using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Todo.TorneSeUmProgramador.Core.Modelos;

namespace Todo.TorneSeUmProgramador.Data.Contexto;

public class TodoAppContexto : DbContext
{
    public TodoAppContexto()
    {
        
    }

    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;

        var databasePath = Path
            .Combine(Environment
            .GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "todoApp.db");

        optionsBuilder.UseSqlite($"Filename={databasePath}");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoAppContexto).Assembly);
    }
}
