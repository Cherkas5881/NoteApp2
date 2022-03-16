using System;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Хранит название, категорию и текст заметки,
    /// а также время ее создания и последнего изменения
    /// </summary>
    public class Note : ICloneable, IEquatable<Note>
    {
        /// <summary>
        /// Название заметки
        /// </summary>
        private string _title = "Без названия";

        /// <summary>
        /// Категория заметки
        /// </summary>
        private NoteCategory _category;

        /// <summary>
        /// Текст заметки
        /// </summary>
        private string _text;

        /// <summary>
        /// Время создания заметки. По умолчанию: только для чтения
        /// </summary>
        private DateTime _isCreated = DateTime.Now;

        /// <summary>
        /// Время изменения файла
        /// </summary>
        private DateTime _isChanged;


        /// <summary>
        /// Возвращает или задает значения "Название заметки"
        /// </summary>
        public string Title
        {
            get => _title;

            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Name length should not exceed 50 characters");
                }

                _title = value != string.Empty ? value : "Без названия";

                IsChanged = DateTime.Now;
            }
        }

        ///<summary>
        ///Возвращает или задает значения "Категория заметки"
        ///</summary>
        public NoteCategory Category
        {
            get => _category;

            set
            {
                _category = value;
                IsChanged = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает или задает значения "Текст заметки"
        /// </summary>
        public string Text
        {
            get => _text;

            set
            {
                _text = value;
                IsChanged = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает или задает значения "Время последнего изменения"
        /// </summary>
        public DateTime IsChanged
        {
            get => _isChanged;

            set => _isChanged = value;
        }

        /// <summary>
        /// Возвращает значения "Время создания заметки"
        /// </summary>
        public DateTime IsCreated
        {
            get => _isCreated;
            set => _isCreated = value;
        }

        /// <summary>
        /// Конструктор класса Note
        /// </summary>
        public Note()
        {

        }

        /// <summary>
        /// Конструктор класса Note для сериализации
        /// </summary>
        /// <param name="title">Не более 50 символов</param>
        /// <param name="category"></param>
        /// <param name="text"></param>
        /// <param name="isCreated"></param>
        /// <param name="isChanged"></param>
        [JsonConstructor]
        public Note(string title, NoteCategory category, string text, DateTime isCreated, DateTime isChanged)
        {
            Title = title;
            Category = category;
            Text = text;
            IsCreated = isCreated;
            IsChanged = isChanged;
        }

        /// <summary>
        /// <inheritdoc cref="ICloneable"/>
        /// </summary>
        /// <returns>Возвращает копию объекта</returns>
        public object Clone()
        {
            return new Note()
            {
                Title = this._title,
                Text = this._text,
                Category = this._category,
                IsCreated = this._isCreated,
                IsChanged = this._isChanged
            };
        }

        /// <summary>
        /// Возвращает результат сравнения двух заметок
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Note other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return _title == other._title
                   && _category == other._category
                   && _text == other._text
                   && _isCreated.Equals(other._isCreated)
                   && _isChanged.Equals(other._isChanged);
        }

        /// <summary>
        /// Возвращает результат сравнения двух заметок
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            return Equals((Note)obj);
        }

        /// <summary>
        /// Возвращает некоторое числовое значение,
        /// которое будет соответствовать данному объекту или его хэш-код
        /// С помощью него можно сравнивать объекты
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_title != null ? _title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)_category;
                hashCode = (hashCode * 397) ^ (_text != null ? _text.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _isCreated.GetHashCode();
                hashCode = (hashCode * 397) ^ _isChanged.GetHashCode();
                return hashCode;
            }
        }

        public string ToFormattedTime(DateTime time)
        {
            return time.ToShortDateString() + @" " + time.ToShortTimeString();
        }
    }
}