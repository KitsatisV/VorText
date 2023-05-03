using System;
using System.Collections.Generic;

namespace VorTextConvos.API.VorTextDB
{
    public partial class UserPass
    {
        public int UserId { get; set; }
        public int PassId { get; set; }

        public virtual Password Pass { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
