using Aoc.Ems.Core;
using Microsoft.EntityFrameworkCore;

namespace Aoc.Ems.Data
{
    public class EmsDbContext : DbContext
    {
        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
    }
}