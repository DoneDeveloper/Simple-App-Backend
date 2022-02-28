using backend.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Car
    {
        [Key]
        public int _id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year_model { get; set; }
        public double price { get; set; }
        public bool licensed { get; set; }
        public string date_added { get; set; }
    }
}
