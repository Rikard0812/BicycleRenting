using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRenting.Models
{
    public class Bicycle
    {
        public Bicycle()
        {
            Reservations = new List<Reservation>();
        }
        public Guid BicycleId { get; set; }
        public int Power { get; set; }
        public Brand Brand { get; set; }
        public string BrandForeignKey { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
