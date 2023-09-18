using System;
using System.Linq;
using System.Text;
using Domain.Commons;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product : AudiTable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public int StockQuantity { get; set; }
        public string Description { get; set; }
    }
}
