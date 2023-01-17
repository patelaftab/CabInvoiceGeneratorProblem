using static CabInvoiceGenerator.RideType;

namespace CabInvoiceGenerator
{
    class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Cab Invoice Generator Program");
            InvoiceGenerator invoioceGenerator = new InvoiceGenerator(RideType.Normal);
            Console.ReadLine();
        }
    }
}