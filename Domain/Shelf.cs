// <copyright file="Shelf.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна 2022. Учебные материалы.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Полка.
    /// </summary>
    public class Shelf : IEquatable<Shelf>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Shelf"/>.
        /// </summary>
        /// <param name="number"> Полка.</param>
        public Shelf(int number)
        {
            this.Number = number;
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Номер полки.
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// Книги.
        /// </summary>
        public ISet<Book> Books { get; } = new HashSet<Book>();

        /// <summary>
        /// Положить книгу на полку.
        /// </summary>
        /// <param name="book">Книга. </param>
        /// <exception cref="ArgumentNullException"> Вставляемый элемент –
        /// <see langword="null"/>. </exception>
        /// <returns> <see langword="true"/>, если положили,
        /// иначе – <see langword="false"/>. </returns>
        public bool PutBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            book.Shelf = this;
            return this.Books.Add(book);
        }

        /// <inheritdoc cref="object.ToString()"/>
        public override string ToString()
        {
            return $"{this.Number}, {string.Join(", ", this.Books)}";
        }

        /// <inheritdoc/>
        public bool Equals(Shelf? other)
        {
            return Equals(this.Id, other?.Id);
        }

        /// <inheritdoc/> cref="GetHashCode"/>
        public override int GetHashCode() => this.Id.GetHashCode();
    }
}
