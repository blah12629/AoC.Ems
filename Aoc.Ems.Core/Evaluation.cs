using System;
using System.Collections.Generic;

namespace Aoc.Ems.Core
{
    public class Evaluation
    {
        public Int32 Id { get; set; } //evalNo
        
        public Int32 EmployeeId { get; set; } //empNo
        public Employee Employee { get; set; }

        public String PerformanceStatus { get; set; } //performanceStatus varchar(20)
    
        public virtual ICollection<User> Users { get; set; }
    }
}