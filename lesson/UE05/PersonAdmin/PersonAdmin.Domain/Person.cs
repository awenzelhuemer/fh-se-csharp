using System;

namespace PersonAdmin.Domain
{
    public record Person
    {
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
    }
}