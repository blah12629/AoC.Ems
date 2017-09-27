using Aoc.Ems.Core;
using Microsoft.EntityFrameworkCore;

namespace Aoc.Ems.Data
{
    public class EmsDbContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<ExamDate> ExamDates { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<InterviewSchedule> InterviewSchedules { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<ScheduleResult> ScheduleResults { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLevel> UserLevels { get; set; }

        public EmsDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Applicant>(builder => 
            {
                builder.HasKey(a => a.Id);
                builder.Property(a => a.Id)
                    .HasColumnName("AppID");
                builder.Property(a => a.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(20);
                builder.Property(a => a.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(20);
                builder.Property(a => a.MiddleName)
                    .HasColumnName("middleName")
                    .HasMaxLength(20);
                builder.Property(a => a.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(20);
                builder.Property(a => a.BirthDate)
                    .HasColumnName("birtDate");
                builder.Property(a => a.Resume)
                    .HasColumnName("resume")
                    .HasColumnType("image");
                builder.Property(a => a.ScheduleNumber)
                    .HasColumnName("schedNo");
                builder.Property(a => a.Id)
                    .HasColumnName("SchedID");
                builder.HasMany(a => a.ExamDates)
                    .WithOne(ed => ed.Applicant)
                    .HasForeignKey(ed => ed.ApplicantId);
                builder.HasMany(a => a.InterviewSchedules)
                    .WithOne(i => i.Applicant)
                    .HasForeignKey(i => i.ApplicantId);
                builder.HasMany(a => a.Users)
                    .WithOne(u => u.Applicant)
                    .HasForeignKey(u => u.ApplicantId);
            });
            modelBuilder.Entity<Attendance>(builder => 
            {
                builder.HasKey(a => a.Id);
                builder.Property(a => a.Id)
                    .HasColumnName("attendanceNo");
                builder.Property(a => a.EmployeeId)
                    .HasColumnName("employeeNo");
                builder.Property(a => a.Status)
                    .HasColumnName("attendanceStatus")
                    .HasMaxLength(20);
                builder.HasOne(a => a.Employee)
                    .WithMany(e => e.Attendances)
                    .HasForeignKey(a => a.EmployeeId);
                builder.HasMany(a => a.Users)
                    .WithOne(u => u.Attendance)
                    .HasForeignKey(u => u.AttendanceId);
            });
            modelBuilder.Entity<Employee>(builder => 
            {
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                    .HasColumnName("EmpID");
                builder.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(20);
                builder.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(20);
                builder.Property(e => e.MiddleName)
                    .HasColumnName("middleName")
                    .HasMaxLength(20);
                builder.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(20);
                builder.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(20);
                builder.Property(e => e.Fingerprint)
                    .HasColumnName("fingerprint")
                    .HasColumnType("image");
                builder.HasMany(e => e.Attendances)
                    .WithOne(a => a.Employee)
                    .HasForeignKey(a => a.EmployeeId);
                builder.HasMany(e => e.Evaluations)
                    .WithOne(e => e.Employee)
                    .HasForeignKey(e => e.EmployeeId);
                builder.HasMany(e => e.Users)
                    .WithOne(u => u.Employee)
                    .HasForeignKey(u => u.EmployeeId);
            });
            modelBuilder.Entity<Evaluation>(builder => 
            {
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                    .HasColumnName("evalNo");
                builder.Property(e => e.EmployeeId)
                    .HasColumnName("empNo");
                builder.Property(e => e.PerformanceStatus)
                    .HasColumnName("performanceStatus")
                    .HasMaxLength(20);
                builder.HasOne(e => e.Employee)
                    .WithMany(e => e.Evaluations)
                    .HasForeignKey(e => e.EmployeeId);
                builder.HasMany(e => e.Users)
                    .WithOne(u => u.Evaluation)
                    .HasForeignKey(u => u.EvaluationId);
            });
            modelBuilder.Entity<ExamDate>(builder => 
            {
                builder.HasKey(ed => ed.Id);
                builder.Property(ed => ed.Id)
                    .HasColumnName("schedNo");
                builder.Property(ed => ed.ApplicantId)
                    .HasColumnName("appID");
                builder.Property(ed => ed.Date)
                    .HasColumnName("dateofExam");
                builder.HasOne(ed => ed.Applicant)
                    .WithMany(a => a.ExamDates)
                    .HasForeignKey(ed => ed.ApplicantId);
            });
            modelBuilder.Entity<ExamResult>(builder => 
            {
                builder.HasKey(er => er.Id);
                builder.Property(er => er.Id)
                    .HasColumnName("resultID");
                builder.Property(er => er.ScheduleId)
                    .HasColumnName("scheduleID");
                builder.Property(er => er.Result)
                    .HasColumnName("examResult")
                    .HasMaxLength(20);
                builder.Property(er => er.Remark)
                    .HasColumnName("examRemark")
                    .HasMaxLength(20);
            });
            modelBuilder.Entity<InterviewSchedule>(builder => 
            {
                builder.HasKey(i => i.Id);
                builder.Property(i => i.Id)
                    .HasColumnName("schedNo");
                builder.Property(i => i.ApplicantId)
                    .HasColumnName("appID");
                builder.Property(i => i.Date)
                    .HasColumnName("dateofInterview");
                builder.HasOne(i => i.Applicant)
                    .WithMany(a => a.InterviewSchedules)
                    .HasForeignKey(i => i.ApplicantId);
            });
            modelBuilder.Entity<Registration>(builder => 
            {
                builder.HasKey(r => r.Id);
                builder.Property(r => r.Id)
                    .HasColumnName("regID");
                builder.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(20);
                builder.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(20);
                builder.Property(e => e.MiddleName)
                    .HasColumnName("middleName")
                    .HasMaxLength(20);
                builder.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(20);
                builder.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(20);
                builder.Property(e => e.BirthDate)
                    .HasColumnName("birthDate");
                builder.Property(r => r.UserLevelId)
                    .HasColumnName("userLevelID");
                builder.HasOne(r => r.UserLevel)
                    .WithMany(ul => ul.Registrations)
                    .HasForeignKey(r => r.UserLevelId);
                builder.HasMany(r => r.Users)
                    .WithOne(u => u.Registration)
                    .HasForeignKey(u => u.RegistrationId);
            });
            modelBuilder.Entity<ScheduleResult>(builder => 
            {
                builder.HasKey(sr => sr.Id);
                builder.Property(sr => sr.Id)
                    .HasColumnName("resultID");
                builder.Property(sr => sr.ScheduleNumber)
                    .HasColumnName("scheduleNo");
                builder.Property(sr => sr.Result)
                    .HasColumnName("resultInterview");
                builder.Property(sr => sr.Remark)
                    .HasColumnName("interviewRemark");
            });
            modelBuilder.Entity<User>(builder => 
            {
                builder.HasKey(u => u.Id);
                builder.Property(u => u.Id)
                    .HasColumnName("userID");
                builder.Property(u => u.EmployeeId)
                    .HasColumnName("employeeID");
                builder.Property(u => u.RegistrationId)
                    .HasColumnName("regNo");
                builder.Property(u => u.AttendanceId)
                    .HasColumnName("attendanceID");
                builder.Property(u => u.ApplicantId)
                    .HasColumnName("applicantID");
                builder.Property(u => u.EvaluationId)
                    .HasColumnName("evaluationID");
                builder.Property(u => u.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(20);
                builder.Property(u => u.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(20);
                builder.Property(u => u.MiddleName)
                    .HasColumnName("middleName")
                    .HasMaxLength(20);
                builder.Property(u => u.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(20);
                builder.Property(u => u.Position)
                    .HasColumnName("position")
                    .HasMaxLength(20);
                builder.Property(u => u.BirthDate)
                    .HasColumnName("birthDate");
                builder.HasOne(u => u.Employee)
                    .WithMany(e => e.Users)
                    .HasForeignKey(u => u.EmployeeId);
                builder.HasOne(u => u.Registration)
                    .WithMany(r => r.Users)
                    .HasForeignKey(u => u.RegistrationId);
                builder.HasOne(u => u.Attendance)
                    .WithMany(a => a.Users)
                    .HasForeignKey(u => u.AttendanceId);
                builder.HasOne(u => u.Applicant)
                    .WithMany(a => a.Users)
                    .HasForeignKey(u => u.ApplicantId);
                builder.HasOne(u => u.Evaluation)
                    .WithMany(e => e.Users)
                    .HasForeignKey(u => u.EvaluationId);
            });
            modelBuilder.Entity<UserLevel>(builder => 
            {
                builder.HasKey(ul => ul.Id);
                builder.Property(ul => ul.Id)
                    .HasColumnName("userLevelID");
                builder.Property(ul => ul.Name)
                    .HasColumnName("userLevelName");
                builder.HasMany(ul => ul.Registrations)
                    .WithOne(r => r.UserLevel)
                    .HasForeignKey(r => r.UserLevelId);
            });
        }
    }
}