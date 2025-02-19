using System.Text.Json.Nodes;
using System.Text.Json;
using System.Reflection;

public class FlightsDAL  : IFlightsDAL{

    public FlightsDAL(){}
    private readonly string STATIC_ORDERS_PATH = "\\coding-assignment-orders.json";

    private JsonObject LoadOrderData(){
        string rawFile = File.ReadAllText(Environment.CurrentDirectory + STATIC_ORDERS_PATH);
        JsonObject jsonObj = null;
        try {
            jsonObj = JsonNode.Parse(rawFile).AsObject();
 
        } catch(Exception ex) {
            Console.WriteLine("ERROR: Failed to parse orders file.", ex.Message);
        }
        return jsonObj;
    }
    public IEnumerable<Order> GetOrders(){
        var ordersJson = LoadOrderData();

        List<Order> orders = new List<Order>();
        foreach(var (key,obj) in ordersJson)
        {
            orders.Add(new Order(){ OrderId = key, DestinationAirportCode = obj["destination"]!.ToString() });
        }
        return orders;
    }

    //Simulating DB access
    public IEnumerable<Flight> GetFlights(){

        List<Flight> flights = new List<Flight>(){
           new Flight() {FlightId = 1, DepartureAirportCode = "YUL", DestinationAirportCode = "YYZ", DepartureDate = 1},
           new Flight() {FlightId = 2, DepartureAirportCode = "YUL", DestinationAirportCode = "YYC", DepartureDate = 1},
           new Flight() {FlightId = 3, DepartureAirportCode = "YUL", DestinationAirportCode = "YVR", DepartureDate = 1},
           new Flight() {FlightId = 4, DepartureAirportCode = "YUL", DestinationAirportCode = "YYZ", DepartureDate = 2},
           new Flight() {FlightId = 5, DepartureAirportCode = "YUL", DestinationAirportCode = "YYC", DepartureDate = 2},
           new Flight() {FlightId = 6, DepartureAirportCode = "YUL", DestinationAirportCode = "YVR", DepartureDate = 2}
        };

        return flights;
    }
}