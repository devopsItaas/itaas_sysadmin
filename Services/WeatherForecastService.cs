namespace itaas_sysadmin.Services;
using itaas_sysadmin.Models;

public class WeatherService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing","Bracing","Chilly","Cool","Mild","Warm","Balmy","Hot","Sweltering","Scorching"
    };

    public IEnumerable<WeatherForecast> GetNext(int days = 5)
    {
        return Enumerable.Range(1, days).Select(i => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(i)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });
    }
}
