// <copyright file="AuthorTests.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна 2022. Учебные материалы.
// </copyright>
namespace Domain.Test
{
    using Domain;

    [TestFixture]
    /// <summary>
    /// Тесты для класса Автор.
    /// </summary>
    public class AuthorTests
    {
        /// <summary>
        /// Тест на конструктор с правильным ФИО.
        /// </summary>
        [Test]
        public void Ctor_Valid_DoesnotThrowException()
        {
            // Arrange
            // Act
            // Assert
            Assert.DoesNotThrow(() => _ = new Author("Пушкин", "Александр", "Сергеевич"));
        }
    }
}