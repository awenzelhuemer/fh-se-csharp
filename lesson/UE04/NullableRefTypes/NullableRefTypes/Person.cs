using System;

#nullable enable

namespace NullableRefTypes
{
    internal class Person
    {
        #region Public Constructors

        public Person(string lastName, string? firstName = null)
        {
            LastName = lastName ?? throw new ArgumentNullException(nameof(LastName));
            FirstName = firstName;
        }

        #endregion

        #region Public Properties

        public string? FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        #endregion
    }
}