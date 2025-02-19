using Flights;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
namespace FlightsDemo;

class Program
{
    static async Task Main(string[] args)
    {
        // User Story 1
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();

        builder.Services.TryAddSingleton<IFlightsService, FlightsService>();
        builder.Services.TryAddSingleton<IFlightsDAL, FlightsDAL>();

        var host = builder.Build();

        Task run = host.RunAsync();

        await Task.WhenAny(run, Task.Run(async () => await ControlLoop(host)));

        await host.StopAsync();
    }

    public async static Task ControlLoop(IHost host)
    {
        while(true)
        {
            string input = Console.ReadLine();
            switch(input){
                case "":
                    await host.StopAsync();
                    break;
                case "1":
                    host.Services.GetRequiredService<IFlightsService>().PrintFlightSchedule();
                    break;
                case "2":
                    host.Services.GetRequiredService<IFlightsService>().PrintOrderItineraries();
                    break;
            }
        }    
    }
}
