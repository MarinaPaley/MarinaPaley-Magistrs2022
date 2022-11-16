// <copyright file="Book.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна 2022. Учебные материалы.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Книга.
    /// </summary>
    public class Book : IEquatable<Book>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="title"> Титул.</param>
        /// <param name="authors">Авторы.</param>
        public Book(string title, ISet<Author> authors)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            this.Title = title;
            this.Authors = authors ?? throw new ArgumentNullException(nameof(authors));
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="title">Титул. </param>
        /// <param name="authors">Авторы. </param>
        public Book(string title, params Author[] authors)
            : this(title, new HashSet<Author>(authors))
        {
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Титул.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Авторы.
        /// </summary>
        public ISet<Author> Authors { get; } = new HashSet<Author>();

        /// <summary>
        /// Полка.
        /// </summary>
        public Shelf? Shelf { get; set; }

        /// <inheritdoc cref="object.ToString()"/>
        public override string ToString()
        {
            return $"{this.Title}, {string.Join(", ", this.Authors)}";
        }

        /// <inheritdoc/>
        public bool Equals(Book? other)
        {
            return Equals(this.Id, other?.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Id.GetHashCode();
    }
}
