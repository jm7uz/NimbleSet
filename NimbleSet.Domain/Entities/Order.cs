using System;
using System.Linq;
using System.Text;
using Domain.Commons;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Order : AudiTable
    {
        public long CustomerId { get; set; }
    
    }
}
