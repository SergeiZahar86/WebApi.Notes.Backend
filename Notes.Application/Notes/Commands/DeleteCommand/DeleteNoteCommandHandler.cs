using MediatR;
using Notes.Application.Common.Exception;
using Notes.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.DeleteCommand
{
    /// <summary>
    /// Обработчик команды 
    /// </summary>
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDbContext _dbContext;
        public DeleteNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;

        /// <summary>
        /// Метод обработки команды
        /// </summary>
        /// <returns><see cref="Unit.Value"/></returns>

        public async Task<Unit> Handle(DeleteNoteCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Notes), request.Id);
            }

            _dbContext.Notes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
