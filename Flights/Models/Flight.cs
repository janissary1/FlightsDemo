

public class Flight {
    public int FlightId {get; set;}
    public string DepartureAirportCode {get;set;}
    public string DestinationAirportCode {get; set;}
    public int DepartureDate {get;set;}

    //public DateTime DepartureDate {get;set;}
    
    // Flight: <>, departure: <>, arrival: <>, day: <>
    // Localization?
    public override string ToString(){
        return $"Flight: {FlightId}, departure: {DepartureAirportCode}, arrival: {DestinationAirportCode}, day:{DepartureDate}";
    }

}