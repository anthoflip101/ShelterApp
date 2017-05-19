using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SheltersApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string AnimalType { get; set; }
        public ICollection<Animal> Animal { get; set; }
    }
}
