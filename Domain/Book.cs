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

            this.Id = Guid.NewGuid();
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

        [Obsolete("For ORM only")]
        protected Book()
        {
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public virtual Guid Id { get; }

        /// <summary>
        /// Титул.
        /// </summary>
        public virtual string Title { get; }

        /// <summary>
        /// Авторы.
        /// </summary>
        public virtual ISet<Author> Authors { get; } = new HashSet<Author>();

        /// <summary>
        /// Полка.
        /// </summary>
        public virtual Shelf? Shelf { get; set; }

        /// <inheritdoc cref="object.ToString()"/>
        public override string ToString()
        {
            return $"{"книга - "}{this.Title}, {string.Join(", ", this.Authors)}";
        }

        /// <inheritdoc/>
        public virtual bool Equals(Book? other)
        {
            return Equals(this.Id, other?.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Id.GetHashCode();
    }
}
