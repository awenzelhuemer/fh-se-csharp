using System;

namespace PersonApi.Dtos
{
    public class DogDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Weight { get; set; }
    }
}
