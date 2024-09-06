using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace kursach_mvvm.Models;

public class ParseAPI
{
    private string _city;
    public static string City;
    public static int Temp;
    public static int MaxTemp;
    public static int MinTemp;
    public static int Wind;
    public static int Pressure;
    public static int Humidity;
    public static int CurrentTemp;
    public static long SunRise;
    public static long SunSet;
    public static string timeSunrise;
    public static string timeSunset;
    public static string id;
    public static string WeatherInfo;
    public ParseAPI(string city)
    {
        this._city = city;
    }

    public async Task API()
    {
            string url =
            $"http://api.openweathermap.org/data/2.5/weather?q={_city}&limit=5&lang=ru&units=metric&appid=eec18a16bce95f9f8c91b4a5bdaa215f";

        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);


        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

        string response;
        using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
        {
            response = streamReader.ReadToEnd();
        }

        WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);


        City = weatherResponse.Name;
        CurrentTemp = (int)Math.Round(weatherResponse.Main.Temp);
        Temp = (int)Math.Round(weatherResponse.Main.Feels);
        MaxTemp = (int)Math.Round(weatherResponse.Main.Temp_Max);
        MinTemp = (int)Math.Round(weatherResponse.Main.Temp_Min);
        Wind = (int)Math.Round(weatherResponse.Wind.Speed);
        SunRise = weatherResponse.Sys.Sunrise + weatherResponse.Timezone;
        SunSet = weatherResponse.Sys.Sunset + weatherResponse.Timezone;
        Pressure = weatherResponse.Main.Pressure;
        Humidity = weatherResponse.Main.Humidity;

        JObject data = JObject.Parse(response);
        WeatherInfo = (string)data["weather"][0]["description"];
        id = (string)data["weather"][0]["icon"];
        
        
        DateTimeOffset dateTimeOffset1 = DateTimeOffset.FromUnixTimeSeconds(SunRise);
        DateTimeOffset utcDateTimeOffset1 = dateTimeOffset1.ToUniversalTime();
        
        DateTimeOffset dateTimeOffset2 = DateTimeOffset.FromUnixTimeSeconds(SunSet);
        DateTimeOffset utcDateTimeOffset2 = dateTimeOffset2.ToUniversalTime();
        
        timeSunrise = utcDateTimeOffset1.ToString("HH:mm");
        timeSunset = utcDateTimeOffset2.ToString("HH:mm");
        


        Console.WriteLine(
            "Температура в {0}: {1} °C , ощущается как {2} °C, скорость ветра {3}, иконка {4}, погода {5}, max {6}, min {7}, давление {8}, влажность {9}, восход {10}, закат {11}",
            City, CurrentTemp, Temp, Wind, id, WeatherInfo, MaxTemp, MinTemp, Pressure, Humidity, timeSunrise, timeSunset);
    }
}