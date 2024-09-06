namespace kursach_mvvm.Models;

public class WeatherResponse
{
    public TemperatureInfo Main { get; set; }
    public WindInfo Wind { get; set; }
    public SunInfo Sys { get; set; }
    public string Name { get; set; }
    public int Timezone { get; set; }
}