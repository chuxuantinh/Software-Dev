using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            //var inputJson = File.ReadAllText("./../../../products.json");

            //var productTemplate = new[] { new
            //{
            //    Name = string.Empty,
            //    Price = 0d,
            //    SellerId = (int?)0,
            //    BuyerId = (int?)0
            //}};

            //var products = JsonConvert.DeserializeAnonymousType(inputJson, productTemplate);


            //var products = JsonConvert.DeserializeObject<ProductDTO[]>(inputJson);

            //DefaultContractResolver resolver = new DefaultContractResolver()
            //{
            //    NamingStrategy = new SnakeCaseNamingStrategy()
            //};

            //var againJson = JsonConvert.SerializeObject(products, Formatting.Indented);

            //var againJson = JsonConvert.SerializeObject(products, new JsonSerializerSettings() 
            //{
            //    ContractResolver = resolver,
            //    Formatting = Formatting.Indented,
            //    NullValueHandling = NullValueHandling.Ignore
            //});

            //Console.WriteLine(againJson);

            //JObject jObject = JObject.Parse(inputJson);

            //foreach (JToken token in jObject["products"])
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(token));
            //    Console.WriteLine(token["Name"]);
            //}

            //var jObject = JObject.Parse(inputJson)["Products"]
            //    .Select(p => $"{p["Name"]}: {p["Price"]}")
            //    .ToList();

            //Console.WriteLine(string.Join(Environment.NewLine, jObject));

            var inputXml = File.ReadAllText("./../../../products.xml");

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(inputXml);

            string json = JsonConvert.SerializeXmlNode(xmlDoc);

            Console.WriteLine(json);
        }
    }
}
