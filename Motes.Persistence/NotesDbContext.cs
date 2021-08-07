using Microsoft.EntityFrameworkCore;
using Motes.Persistence.EntityTypeConfigurations;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Motes.Persistence
{
    public class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Note> Notes { get; set; }
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) { }

        // переопределим этот метод для установления конфигураций наших сущностей
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
