

public class Order {
    public string OrderId {get; set;}
    public string DestinationAirportCode {get; set;}

    public override string ToString()
    {
        return $"order: {OrderId}, flightNumber: not scheduled";
    }
}