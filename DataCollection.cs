using System;
using System.Collections.Generic;
using static System.Console;
using System.IO;
using System.Xml.Serialization;

namespace Weather.WeatherData
{/// <summary>
/// сбор данных
/// </summary>
    public class DataCollection
    {
        private List<WeatherData> list1;

        public List<WeatherData> list { get => list1; set => list1 = value; }
        /// <summary>
        /// добавление данных в лист с данными о погоде
        /// </summary>
        /// <param name="data"></param>
        public void ListAdd(WeatherData data)
        {
            try 
            {
                if (list == null)
                    list = new List<WeatherData>();
                list.Add(data);
            }
            catch(Exception e)
            {
                WriteLine(e.Message);
            }
        }
        /// <summary>
        /// сериализация в xml формат листа с данными
        /// </summary>
        public void Save()
        { XmlSerializer XmlFormat = new XmlSerializer(typeof(List<WeatherData>));
            try
            {
                using (Stream fs = File.Create("weather.xml"))
                {
                    XmlFormat.Serialize(fs, list1);
                }
            }
            catch(Exception e)
            {
                WriteLine(e.Message);
            }
        }
        /// <summary>
        /// десериализация из xml формата в лист с данными
        /// </summary>
        public List<WeatherData> Load()
        {
            List<WeatherData> datas = new List<WeatherData>();
            XmlSerializer XmlFormat = new XmlSerializer(typeof(List<WeatherData>));
            try
            {
                using (Stream fs = File.OpenRead("weather.xml"))
                {
                    datas = (List<WeatherData>)XmlFormat.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            return datas;
        }
        public void Print(List<WeatherData> datas)
        {
            foreach (var item in datas)
            { WriteLine(item.ToString()); }
        }
    }
}
