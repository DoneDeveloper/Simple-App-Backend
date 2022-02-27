using backend.Models.Database;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Car
    {
        [Key,ForeignKey("Warehouse")]
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int YearModel { get; set; }
        public double Price { get; set; }
        public bool Licenced { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual Warehouse Warehouse { get; set; }

    }
}
