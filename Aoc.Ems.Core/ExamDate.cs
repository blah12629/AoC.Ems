using System;

namespace Aoc.Ems.Core
{
    public class ExamDate
    {
        public Int32 Id { get; set; } //schedNo

        public Int32? ApplicantId { get; set; } //appID
        public Applicant Applicant { get; set; }

        public DateTime? Date { get; set; } //dateofExam
    }
}