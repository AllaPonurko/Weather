using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Console;

namespace Weather.WeatherData
{
    public class DataCollectionDictionary
    { 
        public XmlDictionary<DateTime, WeatherData> weatherData { get; set; }
        public DataCollectionDictionary() { }

        public void DictionaryAdd(WeatherData data)
        {
            try
            {
                if (weatherData == null)
                    weatherData = new XmlDictionary<DateTime, WeatherData>();
                weatherData.Add(data.dateTime, data);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
        public void Print(Dictionary<DateTime, WeatherData> datas)
        {
            foreach (var item in datas)
                WriteLine(item.Key.ToString() + "\nДата " + item.Value.ToString());
        }
        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();//двоичное форматирование Dictionary
            try
            {
                using (Stream st = File.Create("dictionary.bin"))
                {
                    formatter.Serialize(st, weatherData);
                }
                WriteLine($"BinarySerialize successfully!");


            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        public Dictionary<DateTime, WeatherData> Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Dictionary<DateTime, WeatherData> dic = new Dictionary<DateTime, WeatherData>();
            try
            {

                using (Stream st = File.OpenRead("dictionary.bin"))
                {
                    dic = (Dictionary<DateTime, WeatherData>)formatter.Deserialize(st);
                }

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            return dic;
        }

    }

}
