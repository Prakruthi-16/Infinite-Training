using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservationSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int TrainNo { get; set; }
        public string ClassOfTravel { get; set; }
        public int SeatsBooked { get; set; }
        public DateTime BookingDate { get; set; }
    }
}