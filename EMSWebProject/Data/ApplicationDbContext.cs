using EMSWebProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EMSWebProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Assets> tblAssets { get; set; }
        public DbSet<EmployeeAssets> tblEmployeeAssets { get; set; }
        public DbSet<EmployeeInfo> tblEmployeeInfo { get; set; }
    }
}
