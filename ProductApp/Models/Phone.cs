using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Maker { get; set; }
        public decimal Price { get; set; }
    }
}
