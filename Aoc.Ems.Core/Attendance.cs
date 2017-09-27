using System;
using System.Collections.Generic;

namespace Aoc.Ems.Core
{
    public class Attendance
    {
        public Int32 Id { get; set; } //attendanceNo
        
        public Int32? EmployeeId { get; set; } //employeeNo
        public Employee Employee { get; set; }

        public String Status { get; set; } //attendanceStatu varchar(20)
        public virtual ICollection<User> Users { get; set; }
    }
}