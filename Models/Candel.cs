using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcCandel.Models
{
    public class Candel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string MadeFrom { get; set; }
        public string Fragrance { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
    }
}
