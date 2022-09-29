// <copyright file="Author.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна 2022. Учебные материалы.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Автор.
    /// </summary>
    public class Author
    {
        private string fullName;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        /// <param name="firstName"> Фамилия.</param>
        /// <param name="lastName"> Имя.</param>
        /// <param name="middleName"> Отчество.</param>
        public Author(string firstName, string lastName, string? middleName)
        {
            this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.MiddleName = middleName;
            this.fullName = this.FullName;
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
        public string FullName
        {
            get => this.fullName;
            set
            {
                if (this.MiddleName is not null)
                {
                    this.fullName =
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
                    this.fullName =
                    string.Concat(this.LastName, " ", this.FirstName[0], ". ");
                }
            }
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
    }
}