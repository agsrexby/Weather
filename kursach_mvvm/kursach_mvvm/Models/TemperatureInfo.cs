using Newtonsoft.Json;

namespace kursach_mvvm.Models;

public class TemperatureInfo
{
    public float Temp { get; set; }
    [JsonProperty ("feels_like")]
    public float Feels { get; set; }
    public float Temp_Min { get; set; }
    public float Temp_Max { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
}