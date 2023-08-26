using Microsoft.AspNetCore.Mvc;

namespace BRR.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {
            
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            return "Hola Mundo";
        }
    }
}