using Microsoft.AspNetCore.Mvc;
using itaas_sysadmin.Models;
using itaas_sysadmin.Services;

namespace itaas_sysadmin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly WeatherService _service;

    public WeatherForecastController(WeatherService service)
    {
        _service = service;
    }

    /// <summary>Pronóstico de los próximos N días (default 5).</summary>
    [HttpGet]
    public ActionResult<IEnumerable<WeatherForecast>> Get([FromQuery] int days = 5)
        => Ok(_service.GetNext(days));
}
