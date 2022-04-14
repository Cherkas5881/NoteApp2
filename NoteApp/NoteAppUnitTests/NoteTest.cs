using System;
using NUnit.Framework;
using NoteApp;

namespace NoteAppUnitTests
{
    /// <summary>
    /// Определение классов юнит-тестирования
    /// </summary>
    [TestFixture]
    public class NoteTest
    {
        /// <summary>
        /// Переменная, хранящая время создания заметки
        /// </summary>
        private readonly DateTime _createdTime = new DateTime(2022, 04, 10, 17, 00, 00);

        /// <summary>
        /// Переменная, хранящая время изменения заметки
        /// </summary>
        private readonly DateTime _changedTime = new DateTime(2022, 04, 10, 17, 05, 00);

        /// <summary>
        /// Метод, выполняющийся каждый раз перед запуском теста
        /// Создает экземпляр заметки
        /// </summary>
        public Note GetSourceNote()
        {
            var sourceNote = new Note();
            sourceNote.Title = "Здесь должен быть текст";
            sourceNote.Category = NoteCategory.Home;
            sourceNote.Text = "Название заметки";
            sourceNote.IsCreated = _createdTime;
            sourceNote.IsChanged = _changedTime;

            return sourceNote;
        }

        [Test(Description = "Позитивный тест геттера Title")]
        public void Title_GetCorrectValue()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = "Здесь должен быть текст";

            //Act
            var actual = sourceNote.Title;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Позитивный тест сеттера Title")]
        public void Title_SetCorrectValue()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = sourceNote.Title;

            //Act
            sourceNote.Title = expected;
            var actual = sourceNote.Title;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера Title с пустым значением")]
        public void Title_SetEmptyValue()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = "Без названия";

            //Act
            sourceNote.Title = "";
            var actual = sourceNote.Title;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера Title с длиной значения" +
                            "поля, превышающего 50 символов")]
        public void Title_SetTooLongValue()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var source = "Слишком длинное название поля," +
                         "превышающее 50 символов и выбрасывающее" +
                         "исключение";

            //Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    // Act
                    sourceNote.Title = source;
                });
        }

        [Test(Description = "Тест геттера Category")]
        public void Category_GetCorrectCategory()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = NoteCategory.Home;

            //Act
            var actual = sourceNote.Category;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера Category")]
        public void Category_SetCorrectValue()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = sourceNote.Category;

            //Act
            sourceNote.Category = expected;
            var actual = sourceNote.Category;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера Text")]
        public void Text_GetCorrectText()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = "Название заметки";

            //Act
            var actual = sourceNote.Text;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера Text")]
        public void Text_SetCorrectValue()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = sourceNote.Text;

            //Act
            sourceNote.Text = expected;
            var actual = sourceNote.Text;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера IsCreated")]
        public void IsCreated_GetCorrectCreatedTime()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = _createdTime;

            //Act
            var actual = sourceNote.IsCreated;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера IsCreated")]
        public void IsCreated_SetCorrectCreatedTime()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = sourceNote.IsCreated;

            //Act
            sourceNote.IsCreated = expected;
            var actual = sourceNote.IsCreated;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера IsChanged")]
        public void IsChanged_GetCorrectChangedTime()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = _changedTime;

            //Act
            var actual = sourceNote.IsChanged;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера IsChanged")]
        public void IsChanged_SetCorrectChangedTime()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = sourceNote.IsChanged;

            //Act
            sourceNote.IsChanged = expected;
            var actual = sourceNote.IsChanged;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест клонирования ICloneable")]
        public void TestClone_ReturnsSameClone()
        {
            //Act
            var sourceNote = GetSourceNote();
            var expected = (Note)sourceNote.Clone();

            //Assert
            Assert.AreEqual(expected, sourceNote);
        }
    }
}