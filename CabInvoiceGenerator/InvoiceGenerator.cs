using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CabInvoiceGenerator.RideType;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private RideRepository rideRepository;

        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMMUM_FARE;

        public InvoiceGenerator(RideType rideType )
        {
            this.rideType = rideType;
            this.rideRepository =rideRepository;
            try
            {
                if (rideType.Equals(Ridetype.Premium))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMMUM_FARE = 20;
                }
                if (rideType.Equals(Ridetype.Normal))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMMUM_FARE = 5;
                }
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
            }
        }
        public double CalculateFare(double Distance, int time)
        {
            double TotalFare = 0;
            try
            {
                TotalFare = Distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch(CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE,"Invalid Ride Type");
                }
                else if (Distance<=0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE,"Invalid Distance");   
                }
                else
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME,"Invalid Time");
                }
            }
            return Math.Max(TotalFare, MINIMMUM_FARE);
        }
    }
}
