using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonApi.Dtos;
using PersonApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        #region Private Fields

        private readonly IMapper mapper;

        private static readonly List<Dog> dogs = new()
        {
            new() { Id = Guid.NewGuid(), Name = "Pepsi", Weight = 10 },
            new() { Id = Guid.NewGuid(), Name = "Chola", Weight = 4 }
        };

        public DogsController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        #endregion

        #region Public Methods

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return dogs.RemoveAll(d => d.Id == id) > 0 ? NoContent() : NotFound();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(dogs.Select(d => mapper.Map<DogDto>(d)));
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var dog = dogs.FirstOrDefault(d => d.Id == id);

            if (dog is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DogDto>(dog));
        }

        [HttpPost]
        public IActionResult Insert(DogDto dog)
        {
            var dogEntity = mapper.Map<Dog>(dog);
            dogEntity.Id = Guid.NewGuid();
            dogs.Add(dogEntity);

            return CreatedAtAction(nameof(Get), new { dogEntity.Id }, dog);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Dog dog)
        {
            var existingDog = dogs.FirstOrDefault(d => d.Id == id);

            if (existingDog is null)
            {
                return NotFound();
            }

            existingDog.Name = dog.Name;
            existingDog.Weight = dog.Weight;

            return NoContent();
        }

        #endregion
    }
}