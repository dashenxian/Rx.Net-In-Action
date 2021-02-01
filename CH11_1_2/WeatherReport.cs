using System;
using System.Collections.Generic;
using System.Text;

namespace CH11_1_2
{
    class WeatherReport
    {
        public string Station { get; set; }
        public double Temperature { get; set; }
        public override string ToString()
        {
            return $"Station:{Station},Temperature:{Temperature}";
        }
    }
}
