using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRenting.Models
{
    public class Customer
    {
        public Customer()
        {
            Reservations = new List<Reservation>();
        }
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
