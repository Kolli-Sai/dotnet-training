using System.Text;

namespace FlightReservationSystem;

internal abstract class Flight
{
    // fields
    private string flightNumber;
    private DateTime deparureTime;
    private DateTime arrivalTime;
    private int totalSeats;
    private int availbleSeats;

    // properties

    public string FlightNumber
    {
        get { return flightNumber; }
        set { flightNumber = value; }
    }

    public DateTime DeparureTime
    {
        get { return deparureTime; }
        set { deparureTime = value; }
    }

    public DateTime ArrivalTime
    {
        get { return arrivalTime; }
        set { arrivalTime = value; }
    }

    public int TotalSeats
    {
        get { return totalSeats; }
        set { totalSeats = value; }
    }

    public int AvailableSeats
    {
        get { return availbleSeats; }
        set { availbleSeats = value; }
    }

    // abstract methods
    public abstract bool Book(int numberOfTickets);
    public abstract bool Cancel(int numberOfTickets);


    // non-abstract methods
    public bool CheckAvailbility(int numberOfTickets)
    {
       
        return numberOfTickets <= this.availbleSeats;
    }

    public virtual string GetAllDetails()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("FlightNumber = {0}{1}", this.FlightNumber, Environment.NewLine);
        sb.AppendFormat("DepartureTime = {0}{1}", this.DeparureTime, Environment.NewLine);
        sb.AppendFormat("ArrivalTime = {0}{1}", this.ArrivalTime, Environment.NewLine);
        sb.AppendFormat("TotalSeats = {0}{1}", this.TotalSeats, Environment.NewLine);
        sb.AppendFormat("AvailbleSeats = {0}{1}", this.AvailableSeats, Environment.NewLine);

        return sb.ToString();
    }


}
