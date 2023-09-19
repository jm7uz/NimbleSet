using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbleSet.Service.Dtos
{
    public class UserForRollUpdate
    {
        public int Id { get; set; }

        public Roll Roll { get; set; }
    }
}
