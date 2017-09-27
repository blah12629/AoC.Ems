using System;

namespace Aoc.Ems.Core
{
    public class Employee
    {
        public Int32 Id { get; set; } //EmpID
        public String FirstName { get; set; } //firstName varchar(20)
        public String LastName { get; set; } //lastName varchar(20)
        public String MiddleName { get; set; } //middleName varchar(20)
        public String Gender { get; set; } //gender varchar(20)
        public String Position { get; set; } //position varchar(20)
        public Byte[] Fingerprint { get; set; } //fingerprint image
    }
}