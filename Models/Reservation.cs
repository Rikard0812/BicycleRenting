using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRenting.Models
{
    public class Reservation
    {
        public Reservation()
        {
            Bicycles = new List<Bicycle>();
        }
        public Guid ReservationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Bicycle> Bicycles { get; set; }
    }
}
