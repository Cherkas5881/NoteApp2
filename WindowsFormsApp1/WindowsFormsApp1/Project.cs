using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    /// <summary>
    /// Хранит список всех заметок
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Возвращает список текущих заметок
        /// </summary>
        public List<Note> Notes { get; set; } = new List<Note>();

        /// <summary>
        /// Возвращает или задает текущий индекс в ListBox
        /// просматрвиаемой заметки
        /// </summary>
        public int CurrentNoteIndex { get; set; }

        /// <summary>
        /// Возвращает отсортированный в порядке убывания
        /// даты изменения заметки список
        /// </summary>
        /// <param name="notSortedList"></param>
        /// <returns></returns>
        public List<Note> SortByEdited(List<Note> notSortedList)
        {
            var sortedNotes = notSortedList.OrderByDescending(item => item.IsChanged).ToList();
            return sortedNotes;
        }

        /// <summary>
        /// Возвращается отсортированный в порядке убывания
        /// даты изменения заметки список определенной категории
        /// </summary>
        /// <param name="notSortedList"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<Note> SortByEditedAndCategory(List<Note> notSortedList, NoteCategory category)
        {
            var sortedNotesCategory = notSortedList.Where(item => item.Category == category).ToList();
            var sortedNotes = sortedNotesCategory.OrderByDescending(item => item.IsChanged).ToList();
            return sortedNotes;
        }
    }
}