using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            // XDocument document = XDocument.Load("Data/cars.xml");
            // Console.WriteLine(File.ReadAllText("Data/cars.xml"));
            // document.Declaration.Version = "3.0";
            // document.Root.Add(new XElement("car", new XElement("make", "Audi")));
            // document.Root.Attribute("address");
            // document.Root.SetAttributeValue("address", "Something academy");
            //document.Save("Data/cars_updated.xml");
            // XElement root = document.Root;
            // root.Attribute("address").Value;
            // root.Attributes();
            // var cars = root.Elements().Where(x => x.Element("make").Value == "Opel").Select(x => new Car()
            // {
            //     Make = x.Element("make").Value,
            //     Model = x.Element("model").Value,
            //     TravelledDistance = long.Parse(x.Element("travelled-distance").Value)
            // }).Where(x => x.Make == "Audi");

            // foreach (var car in cars)
            // {
            //     Console.WriteLine(car);
            // }

            // root.RemoveAll();
            // foreach (var car in cars)
            // {
            //     var carObject = new Car()
            //     {
            //         Make = car.Element("make").Value,
            //         Model = car.Element("model").Value,
            //         TravelledDistance = long.Parse(car.Element("travelled-distance").Value)
            //     };

            //     car.SetElementValue("make", null);
            //     car.Element("make").Value = "Audi";

            //     Console.WriteLine($"{car.Element("make").Value} {car.Element("model")}");

            //     car.RemoveAll();
            // }

            // document.Save("Data/cars_modified.xml");
            var books = new List<Book>
            {
                new Book("The little prince", "Exupery", 1943),
                new Book("The Master and Margarita", "Bulgakov", 1967)
            };

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(File.OpenWrite("books.bin"), books);
            var books = (List<Book>)formatter.Deserialize(File.OpenRead("books.bin"));

            XmlSerializer xmlSerializer = new XmlSerializer(books.GetType());//typeof(List<Book>)
            using (var writer = new StreamWriter("books_new.xml"))
            {
                xmlSerializer.Serialize(writer, books);
            }

            //XmlSerializer carsSerializer = new XmlSerializer(typeof(List<car>));
            XmlSerializer carsSerializer = new XmlSerializer(typeof(List<Car>), new XmlRootAttribute("cars"));// typeof(XmlCars) and without root
            using var reader = new StreamReader("Data/cars.xml"); 
            var cars = (List<Car>)carsSerializer.Deserialize(reader);

            XDocument settings = new XDocument();
            //settings.Add(new XElement("settings", "Test"));
            //settings.Add(new XElement("settings",
            //    new XAttribute("lang", "bg-bg"),
            //    new XElement("XPosition", 
            //        new XElement("X1", "15"),
            //        new XElement("X2", "54")),
            //    new XElement("YPosition", "321")));



            settings.Add(new XElement("books",
                new XElement("book",
                    new XElement("title", "The little prince"),
                    new XElement("author", "Exupery")),
                new XElement("book",
                    new XElement("title", "The Master and Margarita"),
                    new XElement("author", "Bulgakov"))));
            settings.Save("book.xml", SaveOptions.DisableFormatting);
        }

        [Serializable]
        public class Book
        {
            public Book()
            {

            }

            public Book(string title, string author, int year)
            {
                this.Title = title;
                this.Author = author;
                this.Year = year;
            }

            public string Title { get; set; }

            public string Author { get; set; }

            [XmlAttribute]
            public int Year { get; set; }
        }

        [XmlType("cars")]
        public class XmlCars
        {
            [XmlArray]
            public List<Car> Cars { get; set; }
        }

        [XmlType("car")]
        public class Car
        {
            [XmlElement("make")]
            public string Make { get; set; }

            [XmlElement("model")]
            public string Model { get; set; }

            [XmlElement("travelled-distance")]
            public long TravelledDistance { get; set; }

            public override string ToString()
            {
                return $"{this.Make} {this.Model}";
            }
        }
    }
}
