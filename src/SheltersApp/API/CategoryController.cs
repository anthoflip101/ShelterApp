using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SheltersApp.Data;
using SheltersApp.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SheltersApp.API
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var animal = _db.Categories.Include(c => c.Animal).ToList();
            return animal;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string name)
        {
            var animal = _db.Categories.Include(c => c.Animal).Where(c => c.AnimalType == name);
            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        [HttpGet("{id}")]
        public IActionResult GetSpecific(int id)
        {
            var animal = _db.Categories.FirstOrDefault(a => a.Id == id);
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

                _db.Animal.Add(animal);
                _db.SaveChanges();
                return Created("/animal/" + animal.Name, animal);
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
        public void Delete(int id)
        {
        }
    }
}
