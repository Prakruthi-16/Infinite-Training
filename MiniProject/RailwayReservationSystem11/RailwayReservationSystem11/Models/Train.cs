using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservationSystem.Models
{
    public class Train
    {
        public int TrainNo { get; set; }
        public string TrainName { get; set; }
        public string FromStation { get; set; }
        public string Destination { get; set; }
        public decimal Price { get; set; }
        public string ClassOfTravel { get; set; }
        public string TrainStatus { get; set; }
        public int SeatsAvailable { get; set; }
    }
}