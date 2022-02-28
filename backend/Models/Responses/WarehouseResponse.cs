using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Responses
{
    public class WarehouseResponse
    {
        public string _id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public Cars cars { get; set; }

    }
    public class Location
    {
        public string lat { get; set; }
        public string @long { get; set; }
    }

    public class Cars
    {
        public string location { get; set; }
        public List<Car> vehicles { get; set; }
    }
}
