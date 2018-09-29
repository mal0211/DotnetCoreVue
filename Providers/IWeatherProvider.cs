using System.Collections.Generic;
using DotnetCoreVue.Models;

namespace DotnetCoreVue.Providers
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
