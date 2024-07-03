using employeePortal.web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace employeePortal.web.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
