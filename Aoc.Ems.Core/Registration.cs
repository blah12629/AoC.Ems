using System;
using System.Collections.Generic;

namespace Aoc.Ems.Core
{
    public class Registration
    {
        public Int32 Id { get; set; } //regID
        public String LastName { get; set; } //lastName varchar(20)
        public String FirstName { get; set; } //firstName varchar(20)
        public String MiddleName { get; set; } //middleName varchar(20)
        public String Gender { get; set; } //gender varchar(20)
        public DateTime BirthDate { get; set; } //birthDate
        public String Position { get; set; } //position varchar(20)
        
        public Int32 UserLevelId { get; set; } //userLevelID
        public UserLevel UserLevel { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}