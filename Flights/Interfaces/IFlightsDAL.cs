
public interface IFlightsDAL {

    public IEnumerable<Flight> GetFlights();
    public IEnumerable<Order> GetOrders();
}