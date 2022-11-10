// <copyright file="Author.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна 2022. Учебные материалы.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Автор.
    /// </summary>
    public class Author : IEquatable<Author>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        /// <param name="firstName"> Фамилия.</param>
        /// <param name="lastName"> Имя.</param>
        /// <param name="middleName"> Отчество.</param>
        public Author(string lastName, string firstName, string? middleName)
        {
            this.Id = default; // new Guid();
            this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.MiddleName = middleName;
            if (this.MiddleName is not null)
            {
                this.FullName =
                string.Concat(
                    this.LastName,
                    " ",
                    this.FirstName[0],
                    ". ",
                    this.MiddleName[0],
                    ".");
            }
            else
            {
                this.FullName =
                string.Concat(this.LastName, " ", this.FirstName[0], ". ");
            }
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? MiddleName { get; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Книга.
        /// </summary>
        public ISet<Book> Books { get; } = new HashSet<Book>();

        /// <summary>
        /// Добавить книгу.
        /// </summary>
        /// <param name="book"> Кгига. </param>
        /// <exception cref="ArgumentNullException"> Вставляемый элемент –
        /// <see langword="null"/>. </exception>
        /// <returns> <see langword="true"/>, если добавили,
        /// иначе – <see langword="false"/>. </returns>
        public bool AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            book.Authors.Add(this);
            return this.Books.Add(book);
        }

        /// <inheritdoc/>
        public override string ToString()
            => this.FullName;

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is not Author)
            {
                return false;
            }

            return Equals((obj as Author)?.Id, this.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
            => this.Id.GetHashCode();

        /// <inheritdoc/>
        public bool Equals(Author? other)
        {
            return Equals(this.Id, other?.Id);
        }
    }
}