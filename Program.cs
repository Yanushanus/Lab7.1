using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task7
{

    enum type
    {
        Unknown = 0,
        Rain,
        ShortRain,
        Thunder,
        Snow,
        Fog,
        Clouds,
        Sunny
    }
    class WeatherParametersDay
    {
        public double temperatureDay;
        public double temperatureNight;
        public double amountRain;
        public double averagePressure;
        public type typeWeather;
        public WeatherParametersDay()
        {
            temperatureDay = 0;
            temperatureNight = 0;
            amountRain = 0;
            averagePressure = 0;
            typeWeather = type.Unknown;
        }
    }
    class WeatherDays
    {
        WeatherParametersDay[] daysInfo;

        public WeatherDays()
        {
            daysInfo = new WeatherParametersDay[31];
            string path = @"data.txt";
            StreamReader data = new StreamReader(path, Encoding.Default);
            for (int i = 0; i < 31; ++i)
            {
                daysInfo[i] = new WeatherParametersDay();
                string str = data.ReadLine();

                string[] d = new string[str.Split(' ').Length];
                d = str.Split(' ');
                daysInfo[i].temperatureDay = double.Parse(d[0]);
                daysInfo[i].temperatureNight = double.Parse(d[1]);
                daysInfo[i].amountRain = double.Parse(d[2]);
                daysInfo[i].averagePressure = double.Parse(d[3]);
                switch (int.Parse(d[4]))
                {
                    case 0:
                        daysInfo[i].typeWeather = type.Unknown;
                        break;
                    case 1:
                        daysInfo[i].typeWeather = type.Rain;
                        break;
                    case 2:
                        daysInfo[i].typeWeather = type.ShortRain;
                        break;
                    case 3:
                        daysInfo[i].typeWeather = type.Thunder;
                        break;
                    case 4:
                        daysInfo[i].typeWeather = type.Snow;
                        break;
                    case 5:
                        daysInfo[i].typeWeather = type.Fog;
                        break;
                    case 6:
                        daysInfo[i].typeWeather = type.Clouds;
                        break;
                    case 7:
                        daysInfo[i].typeWeather = type.Sunny;
                        break;
                }

            }
        }
        public void InfoOutput()
        {
            int n = 0;
            while (true)
            {
                Console.WriteLine("Enter your day you want to get info out or press 0 to break");
                n = Convert.ToInt32(Console.ReadLine());
                if (n >= 1 && n <= 31)
                {
                    for (int i = 0; i < 31; i++)
                    {
                        if (i == n - 1)
                        {
                            Console.WriteLine($"Your weather on {i + 1} day:");
                            Console.WriteLine("Temperature in day: " + daysInfo[i].temperatureDay);
                            Console.WriteLine("Temperature in night: " + daysInfo[i].temperatureNight);
                            Console.WriteLine("Amount of rain: " + daysInfo[i].amountRain);
                            Console.WriteLine("Average pressure " + daysInfo[i].averagePressure);
                            if (daysInfo[i].typeWeather == type.Unknown)
                            {
                                Console.WriteLine("Unknown type");
                            }
                            else if (daysInfo[i].typeWeather == type.Rain)
                            {
                                Console.WriteLine("Rain ");
                            }
                            else if (daysInfo[i].typeWeather == type.ShortRain)
                            {
                                Console.WriteLine("Shortrain ");
                            }
                            else if (daysInfo[i].typeWeather == type.Thunder)
                            {
                                Console.WriteLine("Thunder ");
                            }
                            else if (daysInfo[i].typeWeather == type.Snow)
                            {
                                Console.WriteLine("Snow ");
                            }
                            else if (daysInfo[i].typeWeather == type.Fog)
                            {
                                Console.WriteLine("Fog ");
                            }
                            else if (daysInfo[i].typeWeather == type.Clouds)
                            {
                                Console.WriteLine("Clouds ");
                            }
                            else if (daysInfo[i].typeWeather == type.Sunny)
                            {
                                Console.WriteLine("Sunny ");
                            }
                        }


                    }
                    continue;

                }
                else if (n == 0)
                {
                    break;
                }
            }
            return;
        }
        public int NumberSunnyDays()
        {
            int k = 0;
            for (int i = 0; i < 31; ++i)
            {
                if (daysInfo[i].typeWeather == type.Sunny)
                {
                    ++k;
                }


            }
            return k;

        }
        public int NumberRainDays()
        {
            int c = 0;
            for (int i = 0; i < 31; ++i)

                if (daysInfo[i].typeWeather == type.Rain || daysInfo[i].typeWeather == type.ShortRain || daysInfo[i].typeWeather == type.Snow)
                    ++c;
            return c;
        }

        public double AverageTemperature()
        {
            double T = 0;
            for (int i = 0; i < 31; ++i)
                T += daysInfo[i].temperatureDay;
            return T / 31;
        }
    }

    class Program
    {
       
        static void Main(string[] args)
        {
            WeatherDays info = new WeatherDays();
            info.InfoOutput();
            Console.WriteLine("Amount of days when was rain or snow: " + info.NumberRainDays());
            Console.WriteLine("Amount of days when sun: " + info.NumberSunnyDays());
            Console.WriteLine("Average temperature: " + info.AverageTemperature());
            Console.ReadKey();
        }
    }
}

