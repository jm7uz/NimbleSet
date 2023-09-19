using Domain.Commons;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : AudiTable
    {
        public Roll roll { get; set; } = Roll.Customer;
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
