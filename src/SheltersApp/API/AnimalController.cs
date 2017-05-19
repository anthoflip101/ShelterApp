using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SheltersApp.Data;
using SheltersApp.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SheltersApp.API
{
    [Route("api/[controller]")]
    public class AnimalController : Controller
    {
        private ApplicationDbContext _db;

        public AnimalController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            return _db.Animal.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var animal = _db.Animal.Where(c => c.Id == id).FirstOrDefault();
            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Animal animal)
        {
            if (animal != null)
            {
                if (animal.Id == 0)
                {
                    _db.Animal.Add(animal);
                    _db.SaveChanges();
                    return Created("/animal/" + animal.Name, animal);

                }
                else
                {

                    var original = _db.Animal.FirstOrDefault(m => m.Id == animal.Id);
                    original.Name = animal.Name;
                    original.Bio = animal.Bio;
                    original.Image = animal.Image;
                    original.Breed = animal.Breed;
                    _db.SaveChanges();
                    return Ok(animal);
                }
                
            }


            return NotFound();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var animal = _db.Animal.FirstOrDefault(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }
            _db.Animal.Remove(animal);
            _db.SaveChanges();
            return Ok();
        }
    }
}
