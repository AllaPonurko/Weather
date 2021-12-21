using System;
using static System.Console;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace Weather.WeatherData
{
    
    class Program
    { 
        static void Main(string[] args)
        {
            DateTime time =new DateTime(2021,12,18,6,50,30);
            DateTime time1 = new DateTime(2020, 12, 06, 18, 35, 30);
            WeatherData weatherData = new WeatherData(18.3, 12, 754);
            WriteLine(weatherData.ToString());
            WeatherData weatherData1 = new WeatherData(time);
            WriteLine(weatherData1.ToString());
            WeatherData weatherData2 = new WeatherData(time1);
            WriteLine(weatherData2.ToString());
            //DataCollection data = new DataCollection();
            //data.ListAdd(weatherData);
            //data.ListAdd(weatherData1);
            //data.ListAdd(weatherData2);
            //data.Save();
            DataCollectionDictionary dictionary = new DataCollectionDictionary();
            dictionary.DictionaryAdd(weatherData);
            dictionary.DictionaryAdd(weatherData1);
            dictionary.DictionaryAdd(weatherData2);
            WriteLine("Выгруженные данные:\n");
            //data.Print(data.Load());
            //dictionary.Save();//сериализация в двоичном формате
            //dictionary.Print(dictionary.Load());//выгрузка из бинарного файла
            Stream fs = File.Create("weatherDictionary.xml");
            XmlWriterSettings settings =new XmlWriterSettings();
            settings.Async = true;
            XmlWriter writer = XmlWriter.Create(fs, settings);
            dictionary.WriteXml(writer);
            writer.Close();
            //Stream f = File.OpenRead("weatherDictionary.xml");
            //XmlReader reader = XmlReader.Create(f);
            //dictionary.ReadXml(reader);
            //reader.Close();
        }
    }
}
