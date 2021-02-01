using System;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH11_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherStationA = Observable.Throw<WeatherReport>(new OutOfMemoryException());

            var weatherStationB = Observable.Return<WeatherReport>(new WeatherReport { Station = "B", Temperature = 20.0 });

            weatherStationA
                .OnErrorResumeNext(weatherStationB)
                .SubscribeConsole("WeatherStationA");

            weatherStationB
                .OnErrorResumeNext(weatherStationB)
                .SubscribeConsole("weatherStationB");
        }
    }
}
