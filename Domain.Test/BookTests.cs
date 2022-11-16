namespace Domain.Tests
{
    using System.Collections;

    /// <summary>
    /// Модульные тесты для <see cref="Book"/>.
    /// </summary>
    [TestFixture]
    public sealed class BookTests
    {
        /// <summary>
        /// Конструктор с правильными параметрами.
        /// </summary>
        [Test]
        public void Ctor_ValidData_DoesNotThrowException()
        {
            // Arrange
            var author = new Author("Пушкин", "Александр", "Сергеевич");

            // Act & Assert
            Assert.DoesNotThrow(() => _ = new Book("Сказки", author));
        }

        /// <summary>
        /// Проверка выброса исключения на неправильный титул.
        /// </summary>
        /// <param name="title"> титул. </param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_NoTitle_ThrowException(string? title)
        {
            // Arrange
            var author = new Author("Пушкин", "Александр", "Сергеевич");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Book(title, author));
        }

        /// <summary>
        /// Проверка выброса исключения на NULL автора.
        /// </summary>
        [Test]
        public void Ctor_AuthorIsNull_NoException()
        {
            // Arrange
            Author? author = null;

            // Act & Assert
            Assert.DoesNotThrow(() => _ = new Book("Война и мир", author));
        }

        /// <summary>
        /// Проверка вывода в строку книги в соавторстве.
        /// </summary>
        [Test]
        public void ToString_ValidData_Success()
        {
            // Arrange
            var author1 = new Author("Ильф", "Илья", "Арнольдович");
            var author2 = new Author("Петров", "Евгений", "Петрович");
            var book = new Book("12 Стульев", author1, author2);
            var expected = "12 Стульев, Ильф И. А., Петров Е. П.";

            // Act
            var actual = book.ToString();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
