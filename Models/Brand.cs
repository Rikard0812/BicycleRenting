using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRenting.Models
{
    public class Brand
    {
        public Brand()
        {
            Bicycles = new List<Bicycle>();
        }
        public string BicycleBrand { get; set; }
        public ICollection<Bicycle> Bicycles { get; set; }
    }
}
