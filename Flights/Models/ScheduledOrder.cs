

public class ScheduledOrder : Order {
    public int FlightId {get;set;}
    public string DepartureAirportCode {get;set;}
    public int DepartureDate {get;set;}

    public override string ToString()
    {
        return $"order: {OrderId}, flightNumber: {FlightId}, departure: {DepartureAirportCode}, arrival: {DestinationAirportCode}, day:{DepartureDate}";
    }

    /// <summary>
    /// Convenience function for casting flight and order together
    /// </summary>
    /// <param name="flight"></param>
    /// <param name="order"></param>
    /// <returns>ScheduledOrder</returns>
    public static ScheduledOrder ScheduleOrder(Flight flight, Order order)
    {
        return new ScheduledOrder()
            { 
                OrderId = order.OrderId, 
                FlightId = flight.FlightId,
                DepartureAirportCode = flight.DepartureAirportCode, 
                DestinationAirportCode = flight.DestinationAirportCode, 
                DepartureDate = flight.DepartureDate,  

            };
    }
}