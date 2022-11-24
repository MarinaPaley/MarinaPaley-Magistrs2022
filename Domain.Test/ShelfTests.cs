// <copyright file="ShelfTests.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна 2022. Учебные материалы.
// </copyright>

namespace Domain.Test
{
    /// <summary>
    /// Модульные тесты для <see cref="Shelf"/>.
    /// </summary>
    [TestFixture]
    public class ShelfTests
    {
        /// <summary>
        /// Конструктор с правильными параметрами.
        /// </summary>
        [Test]
        public void Ctor_ValidData_Success()
        {
            Assert.DoesNotThrow(() => _ = new Shelf(1));
        }

        /// <summary>
        /// Проверка метода Положить книгу на полку.
        /// </summary>
        [Test]
        public void PutBookOnShelf_ValidDtata_Success()
        {
            // Arrange
            var shelf = new Shelf(1);
            var author = new Author("Пушкин", "Александр", "Сергеевич");
            var book1 = new Book("Сказка о золотом петушке", author);
            var book2 = new Book("Дубровский", author);

            // Act
            var result = shelf.PutBook(book1);
            shelf.PutBook(book2);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(shelf.Books, Has.Count.EqualTo(2));
        }

        /// <summary>
        /// Проверка вывода в строку.
        /// </summary>
        [Test]
        public void ToString_Success()
        {
            // Arrange
            var shelf = new Shelf(1);
            var author = new Author("Пушкин", "Александр", "Сергеевич");
            var book1 = new Book("Сказка о золотом петушке", author);
            var book2 = new Book("Дубровский", author);
            var expected = "Полка - 1, книга - Сказка о золотом петушке," +
                " Пушкин А. С., книга - Дубровский, Пушкин А. С.";

            // Act
            var result = shelf.PutBook(book1);
            shelf.PutBook(book2);

            // Assert
            Assert.That(expected, Is.EqualTo(shelf.ToString()));
        }
    }
}
