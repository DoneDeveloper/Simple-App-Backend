using backend.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
     public class Warehouse
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public List<Car> Cars { get; set; }
    }

}
