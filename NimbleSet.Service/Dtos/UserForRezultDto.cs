using System;
using System.Linq;
using System.Text;
using Domain.Enums;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Services.Dtos
{
    public class UserForRezultDto
    {
        public long Id { get; set; }
        public Roll roll { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }

    }
}
