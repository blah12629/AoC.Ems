using System;
using System.Collections.Generic;

namespace Aoc.Ems.Core
{
    public class UserLevel
    {
        public Int32 Id { get; set; } //userLevelID
        public String Name { get; set; } //userLevelName

        public virtual ICollection<Registration> Registrations { get; set; }
    }
}