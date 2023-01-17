using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        public double Distance;
        public int Time;

        public Ride (double distance, int time)
        {
            Distance = distance;
            Time = time;
        }
    }
}
