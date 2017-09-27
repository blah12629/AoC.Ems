using System;

namespace Aoc.Ems.Core
{
    public class Attendance
    {
        public Int32 Id { get; set; } //attendanceNo
        
        public Int32 EmployeeId { get; set; } //employeeNo
        public Employee Employee { get; set; }

        public String Status { get; set; } //attendanceStatud varchar(20)
    }
}