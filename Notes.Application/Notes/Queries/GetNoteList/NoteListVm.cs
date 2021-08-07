using System.Collections.Generic;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    /// <summary>
    /// Класс для возвращения пользователю по запросу GET. Использующий маппинг
    /// </summary>
    public class NoteListVm 
    {
        /// <summary>
        /// Класс для возвращения пользователю по запросу GET. Использующий маппинг
        /// </summary>
        public NoteListVm() { }
        /// <summary>
        /// Коллекция заметок
        /// </summary>
        public IList<NoteLookupDto> Notes { get; set; }
    }
}
