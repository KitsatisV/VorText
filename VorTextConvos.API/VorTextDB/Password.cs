using System;
using System.Collections.Generic;

namespace VorTextConvos.API.VorTextDB
{
    public partial class Password
    {
        public int PassId { get; set; }
        public string Username { get; set; } = null!;
        public string Password1 { get; set; } = null!;

        public virtual UserPass? UserPass { get; set; }
    }
}
