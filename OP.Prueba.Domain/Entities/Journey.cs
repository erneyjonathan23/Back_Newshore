using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Domain.Entities
{
    public class Journey
    {
        public Journey()
        {
            Flights = new HashSet<Flight>();
        }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }

    }
}
