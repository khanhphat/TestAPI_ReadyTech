using CoffeeMachine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMachine.Models
{
    public class CoffeeCup
    {
        public string Message { get; set; }
        public string Prepared { get; set; }
        public CoffeeCup()
        {
            Message = "Your piping hot coffee is ready";
            Prepared = DateTime.Now.ToString(Contants.FORMAT_FULL_DATE);
        }
    }

    //singleton
    public class AccessCount
    {
        public int AccessNumber { get; set; }
        public static AccessCount Instance = new AccessCount();
        public AccessCount()
        {
            AccessNumber = 0;
        }
        public void Count()
        {
            AccessNumber++;
        }
    }

    public class WeatherBase
    {
        public Coord Coord { get; set; } = new Coord();
        public List<Weather> Weather { get; set; } = new List<Weather>();
        public string Base { get; set; }
        public Main Main { get; set; } = new Main();
        public int Visibility { get; set; }
        public Wind Wind { get; set; } = new Wind();
        public Clouds Clouds { get; set; } = new Clouds();
        public int Dt { get; set; }
        public Sys Sys { get; set; } = new Sys();
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }

    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
    public class Main
    {
        public double Temp { get; set; }
        public double Feels_Like { get; set; }
        public double Temp_Min { get; set; }
        public double Temp_Max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public double Message { get; set; }
        public string Sunrise { get; set; }
        public int Sunset { get; set; }
    }
}
