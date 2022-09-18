using Newtonsoft.Json;

namespace NxFullstack.GroupSv;

public class WeatherForecast
{
    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("temperature_c")]
    public int TemperatureC { get; set; }

    [JsonProperty("temperature_f")]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    [JsonProperty("summary")]
    public string? Summary { get; set; }
}
