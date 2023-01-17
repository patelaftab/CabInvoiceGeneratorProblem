using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;
        public RideRepository()
        {
            this.userRides=new Dictionary<string, List<Ride>>();
        }

        public void AddRide(string UserId, Ride[] rides)
        {
            bool rideList=this.userRides.ContainsKey(UserId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(UserId, list);
                }
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides Are Null");
            }
        }
        public Ride[] GetRides(string UserId) 
        {
            try
            {
                return this.userRides[UserId].ToArray();
            }
            catch(Exception)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid User Id");
            }

        }
    }

}
