using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
    public class ProductDTO
    {
        [JsonProperty("Title")]
        public string Name { get; set; }

        public double Price { get; set; }

        public int SellerId { get; set; }

        public int? BuyerId { get; set; }

        [JsonIgnore]
        public int Quantity { get; set; }
    }
}
