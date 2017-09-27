using System;

namespace Aoc.Ems.Core
{
    public class ExamResult
    {
        public Int32 Id { get; set; } //resultID
        
        public Int32? ScheduleId { get; set; } //scheduleID

        public String Result { get; set; } //examResult
        public String Remark { get; set; } //examRemark
    }
}