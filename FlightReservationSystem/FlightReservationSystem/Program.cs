namespace FlightReservationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime departure = new DateTime(2024, 4, 13, 9, 0, 0);
            DateTime arrival = new DateTime(2024, 4, 13, 11, 0, 0);
            Domestic d1 = new Domestic("d1", departure, arrival, 100, 50);
            //d1.Book(10);
            //d1.Cancel(5);
            Console.WriteLine(d1.GetAllDetails());

        }
    }
}
