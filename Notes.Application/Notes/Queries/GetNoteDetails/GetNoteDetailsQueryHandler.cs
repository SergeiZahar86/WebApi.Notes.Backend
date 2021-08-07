using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exception;
using Notes.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    /// <summary>
    /// Обработчик команды 
    /// </summary>
    internal class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetNoteDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        /// <summary>
        /// Метод обработки запроса
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundExeption(nameof(Notes), request.Id);
            }
            return _mapper.Map<NoteDetailsVm>(entity);
        }
    }
}
