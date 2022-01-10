using System;

namespace PersonApi.Models
{
    public class Dog
    {
        #region Public Properties

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }

        #endregion
    }
}