using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Flights;
public class FlightsService : IFlightsService {

    private readonly int MAX_ORDERS_PER_FLIGHT = 20;
    private IFlightsDAL _flightsDAL;
    public FlightsService(IFlightsDAL flightsDAL)
    {
        _flightsDAL = flightsDAL;
    }

    public void PrintFlightSchedule(){
        var flights = _flightsDAL.GetFlights();
        foreach(Flight flight in flights)
        {
            Console.WriteLine(flight);
        }
    }

    public void PrintOrderItineraries(){
        var orders = _flightsDAL.GetOrders().ToList();
        var flights = _flightsDAL.GetFlights();

        List<ScheduledOrder> scheduledOrders = new List<ScheduledOrder>();

        foreach(var flight in flights)
        {
            var eligibleOrderBatch = orders.Where((order) => order.DestinationAirportCode.Equals(flight.DestinationAirportCode)).Take(MAX_ORDERS_PER_FLIGHT);
            scheduledOrders.AddRange(eligibleOrderBatch.Select((eligibleOrder) => ScheduledOrder.ScheduleOrder(flight,eligibleOrder)));

            //Remove Orders that were eligible.
            var eligibleHash = eligibleOrderBatch.Select((x) => x.OrderId).ToHashSet();
            orders.RemoveAll((x) => eligibleHash.Contains(x.OrderId));
        }
        
        // Print scheduled orders
        scheduledOrders.ForEach(Console.WriteLine);

        //Print orders that could not be scheduled
        orders.ForEach(Console.WriteLine);

    }

}