// <copyright file="AuthorTests.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна 2022. Учебные материалы.
// </copyright>
namespace Domain.Test
{
    using Domain;

    /// <summary>
    /// Тесты для класса Автор.
    /// </summary>
    [TestFixture]
    public class AuthorTests
    {
        /// <summary>
        /// Тест на конструктор с правильным ФИО.
        /// </summary>
        /// <param name="middleName"> Отчество. </param>
        [Test]
        [TestCase("Сергеевич")]
        [TestCase(null)]
        public void Ctor_Valid_DoesnotThrowException(string? middleName)
        {
            // Arrange
            // Act
            // Assert
            Assert.DoesNotThrow(() => _ = new Author("Пушкин", "Александр", middleName));
        }

        /// <summary>
        /// Тест на конструктор с неправильной фамилией.
        /// </summary>
        /// <param name="lastName"> Фамилия.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_WrongLastName_ThrowException(string? lastName)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Author(lastName, "Александр", "Сергеевич"));
        }

        /// <summary>
        /// Тест на конструктор с неправильной фамилией.
        /// </summary>
        /// <param name="firstName"> Имя.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_WrongFirstName_ThrowException(string? firstName)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Author("Пушкин", firstName, "Сергеевич"));
        }

        /// <summary>
        /// Пустое Отчество. Ожидается выброс исключения.
        /// </summary>
        [Test]
        public void Ctor_WrongMiddleName_ThrowException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Author("Пушкин", "Александр", string.Empty));
        }

        /// <summary>
        /// Проверка на эквивиалентность двух одинаковых экземпляров.
        /// </summary>
        [Test]
        public void AreEquals_Success()
        {
            // Arrange
            var author = new Author("Пушкин", "Александр", "Сергеевич");
            var author2 = author;

            // Act & Assert
            Assert.That(author, Is.EqualTo(author2));
        }

        /// <summary>
        /// Проверка на преобразование в строку. Имеется отчество.
        /// </summary>
        [Test]
        public void ToString_ValidData_Success()
        {
            // Arrange
            var author = new Author("Пушкин", "Александр", "Сергеевич");
            var expected = "Пушкин А. С.";

            // Act & Assert
            Assert.That(author.ToString(), Is.EqualTo(expected));
        }

        /// <summary>
        /// Проверка на преобразование в строку. Не имеется отчество.
        /// </summary>
        [Test]
        public void ToString_EmptyMiddleName_Success()
        {
            // Arrange
            var author = new Author("Пушкин", "Александр");
            var expected = "Пушкин А.";

            // Act & Assert
            Assert.That(author.ToString(), Is.EqualTo(expected));
        }

        /// <summary>
        /// Добавление книг автору.
        /// </summary>
        [Test]
        public void AddBook_ValidData_Success()
        {
            // Arrange
            var author = new Author("Пушкин", "Александр", "Сергеевич");
            var book1 = new Book("Сказка о рыбаке и рыбке", author);
            var book2 = new Book("Сказка о попе и работнике его Балде", author);

            // Assert
            Assert.IsTrue(author.AddBook(book1));
            Assert.IsTrue(author.AddBook(book2));
            Assert.That(author.Books.Count, Is.EqualTo(2));
        }
    }
}