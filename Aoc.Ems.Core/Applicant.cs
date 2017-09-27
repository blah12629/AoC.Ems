using System;
using System.Collections.Generic;

namespace Aoc.Ems.Core
{
    public class Applicant
    {
        public Int32 Id { get; set; } //AppID
        public String FirstName { get; set; } //firstName varchar(20)
        public String LastName { get; set; } //lastName varchar(20)
        public String MiddleName { get; set; } //middleName varchar(20)
        public String Gender { get; set; } //gender varchar(20)
        public DateTime? BirthDate { get; set; } //birtDate
        public Byte[] Resume { get; set; } //resume
        public Int32? ScheduleNumber { get; set; } //schedNo
        public Int32? ScheduleId { get; set; } //schedID

        public virtual ICollection<ExamDate> ExamDates { get; set; }
        public virtual ICollection<InterviewSchedule> InterviewSchedules { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}