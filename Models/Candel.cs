using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCandel.Models
{
    public class Candel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string MadeFrom { get; set; }
        public string Fragrance { get; set; }
        [Display(Name = "Expiry Date")]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string Rating { get; set; }
    }
}
