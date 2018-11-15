using System.Collections.Generic;

namespace Pharmacies.Models
{
    public class Region
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}