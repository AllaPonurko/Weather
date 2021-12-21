using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.WeatherData
{[Serializable]
    public class WeatherData
    {
        public double Temperature { set; get; }
        public int WindSpeed{ set; get; }
        public int Pressure { set; get; }

        public override bool Equals(object obj)
        {
            return obj is WeatherData date &&
                   Pressure == date.Pressure;
        }
        public DateTime dateTime = new DateTime();
        /// <summary>
        /// конструктор с тремя параметрами
        /// </summary>
        /// <param name="T">temperature</param>
        /// <param name="WS">windspeed</param>
        /// <param name="P">pressure</param>
        public WeatherData(double T,int WS,int P)
        {
            Temperature = T;
            WindSpeed = WS;
            Pressure = P;
            dateTime=DateTime.Now;
        }
        public WeatherData(DateTime time)
        {
            Random random = new Random();
            if (time.Month == 1 || time.Month == 2 || time.Month == 12 && time.Hour >= 6.00 && time.Hour < 9.00)
            {
                Temperature = random.Next(0, 18) * (-1.33);
                Pressure = random.Next(750, 765);
                WindSpeed = random.Next(0, 12);
            }
            if (time.Month == 1 || time.Month == 2 || time.Month == 12 && time.Hour >= 9.00 && time.Hour < 17.00)
            {
                Temperature = random.Next(0, 8) * (-1.33);
                Pressure = random.Next(750, 765);
                WindSpeed = random.Next(4, 18);
            }
            if (time.Month == 1 || time.Month == 2 || time.Month == 12 && time.Hour >= 17.00 &&
                time.Hour <= 24.00 )
            {
                Temperature = random.Next(0, 12) * (-1.33);
                Pressure = random.Next(750, 765);
                WindSpeed = random.Next(2,10);
            }
            if (time.Month == 1 || time.Month == 2 || time.Month == 12 && time.Hour >0.00 &&
                time.Hour < 6.00)
            {
                Temperature = random.Next(0, 14) * (-1.33);
                Pressure = random.Next(750, 765);
                WindSpeed = random.Next(0,4);
            }
            dateTime = time;
        }
        public WeatherData() { }
        public override string ToString()
        {
            return $"{dateTime}\n" +$"{Temperature}"+" C\n"+$"{Pressure }"+ " units of mercury column\n"+$"{WindSpeed}"+" m/c\n";
        }
        
    }
}
