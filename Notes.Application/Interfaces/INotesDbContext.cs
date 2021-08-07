using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Interfaces
{
    /// <summary>
    /// Интерфейс контекста базы данных
    /// </summary>
    public interface INotesDbContext 
    {
        DbSet<Note> Notes { get; set; }
        // дублируем сигнатуру это метода из DbContext EntityFrameworkCore для удобства
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
