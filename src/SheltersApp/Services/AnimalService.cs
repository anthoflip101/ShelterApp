using SheltersApp.Data;
using SheltersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SheltersApp.Services
{
    public class AnimalService
    {
        private ApplicationDbContext _db;

        public void AnimalController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Animal> ListAnimal()
        {
            return _db.Animal.ToList();
        }

        public Animal FindAnimal(int id)
        {
            return _db.Animal.First(a => a.Id == id);
        }
    }
}
