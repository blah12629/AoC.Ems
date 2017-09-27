using System;

namespace Aoc.Ems.Core
{
    public class User
    {
        public Int32 Id { get; set; } //userID
        
        public Int32? EmployeeId { get; set; } //employeeID
        public Employee Employee { get; set; }

        public Int32? RegistrationId { get; set; } //regNo
        public Registration Registration { get; set; }

        public Int32? AttendanceId { get; set; } //attendanceID
        public Attendance Attendance { get; set; }

        public Int32? ApplicantId { get; set; } //applicantID
        public Applicant Applicant { get; set; }

        public Int32? EvaluationId { get; set; } //evaluationID
        public Evaluation Evaluation { get; set; }

        public String LastName { get; set; } //lastName varchar(20)
        public String FirstName { get; set; } //firstName varchar(20)
        public String MiddleName { get; set; } //middleName varchar(20)
        public String Gender { get; set; } //gender varchar(20)
        public DateTime? BirthDate { get; set; } //birthDate
        public String Position { get; set; } //position
    }
}