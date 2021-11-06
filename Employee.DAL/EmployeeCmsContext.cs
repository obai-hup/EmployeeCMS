using Employee.Domain;
using Microsoft.EntityFrameworkCore;

namespace Employee.DAL
{
    public class EmployeeCmsContext : DbContext
    {
        public EmployeeCmsContext(DbContextOptions<EmployeeCmsContext> options) : base(options)
        {
        }

        public DbSet<Employer> Employers { get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<Country> Countries{ get; set; }
    }
}
