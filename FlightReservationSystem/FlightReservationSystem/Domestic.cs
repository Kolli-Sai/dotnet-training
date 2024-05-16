using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{
    internal sealed class Domestic : Flight
    {
        // fields specific to Domestic class
        private int baggageAllowance;

        public int BaggageAllowance
        {
            get { return baggageAllowance; }
            set { baggageAllowance = value; }
        }

        // constructor
        public Domestic(string flightNumber, DateTime departureTime, DateTime arrivalTime, int totalSeats, int availbleSeats)
        {
            this.FlightNumber = flightNumber;
            this.DeparureTime = departureTime;
            this.ArrivalTime = arrivalTime;
            this.TotalSeats = totalSeats;
            this.AvailableSeats = availbleSeats;

        }

        // implementation of abstract methods
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

        // non-abstract methods

        public void UpdateBaggageAllowance(int baggageAllowance)
        {
            BaggageAllowance = baggageAllowance;
        }

        public override string GetAllDetails()
        {
            StringBuilder sb = new StringBuilder(base.GetAllDetails());
            sb.AppendFormat("BaggageAllowance = {0}{1}", this.BaggageAllowance, Environment.NewLine);

            return sb.ToString();

        }


    }
}
