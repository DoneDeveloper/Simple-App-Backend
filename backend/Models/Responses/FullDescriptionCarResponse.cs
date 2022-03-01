using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Responses
{
    public class FullDescriptionCarResponse
    {
        public Car car { get; set; }
        public string warehouseId { get; set; }
        public string warehouseName { get;set;}
        public string warehouseLocationName { get; set; }
        public string warehouseLocationLong { get; set; }
        public string warehouseLocationLat { get; set; }
    }
}
