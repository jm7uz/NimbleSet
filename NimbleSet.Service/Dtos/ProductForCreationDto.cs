using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Services.Dtos
{
    public class ProductForCreationDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public int StockQuantity { get; set; }
        public string Description { get; set; }
    }
}
