using System;
using System.Collections.Generic;

namespace VorTextConvos.API.VorTextDB
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;

        public virtual UserPass? UserPass { get; set; }
    }
}
