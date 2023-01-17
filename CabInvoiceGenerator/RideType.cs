using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideType
    {
        public static RideType Normal { get; internal set; }

        public enum Ridetype { Normal,Premium}
    }
}
