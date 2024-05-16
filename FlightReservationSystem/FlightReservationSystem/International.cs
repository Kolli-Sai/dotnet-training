using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{
    internal sealed class International : Flight
    {
        // constructor
        public International(string flightNumber, DateTime departureTime, DateTime arrivalTime, int totalSeats, int availbleSeats)
        {
            this.FlightNumber = flightNumber;
            this.DeparureTime = departureTime;
            this.ArrivalTime = arrivalTime;
            this.TotalSeats = totalSeats;
            this.AvailableSeats = availbleSeats;

        }

        // abstract methods implementation
        public override bool Book(int numberOfTickets)
        {
            if (numberOfTickets <= AvailableSeats)
            {
                AvailableSeats -= numberOfTickets;
                return true;
            }
            return false;
        }

        public override bool Cancel(int numberOfTickets)
        {
            if (numberOfTickets <= AvailableSeats)
            {
                AvailableSeats += numberOfTickets;
                return true;
            }
            return false;
        }

        // non-abstract method
        public int CaluclateVissaFee(string country)
        {
            if(country == "USA")
            {
                return 200;
            }

            return 100;
        }
    }
}
