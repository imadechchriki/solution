using Microsoft.EntityFrameworkCore;
using AbsenceManagement.Models;

namespace AbsenceManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Absence> Absences { get; set; }
    }
}