using System;
using System.Linq;
using System.Text;
using Domain.Commons;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class OrderDetails : AudiTable
    {
        public long OrderId { get; set; }
        public int Quantity { get; set; }
        public long ProductId { get; set; }
    }
}
