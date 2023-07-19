using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabamcom.Core.DTOs
{
    public class AdvertAllDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int Km { get; set; }
        public string Color { get; set; }
        public string Gear { get; set; }
        public string Fuel { get; set; }
        public string FirstPhoto { get; set; }
    }
}
