using Microsoft.EntityFrameworkCore;
using OfficeManagement.Web.Model;

namespace OfficeManagement.Web.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {        
        private readonly IConfiguration _config;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connetionString = _config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connetionString);
            }
        }
    }
}
