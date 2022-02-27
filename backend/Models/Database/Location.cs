using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Database
{
    public class Location
    {
        [ForeignKey("Warehouse")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
