using Microsoft.EntityFrameworkCore;

namespace TestAPP.Entity
{
    public class AppDbContext : DbContext
    {
        public IConfiguration Configuration { get; }
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DbSet<RequestHistory> RequestHistorys { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RequestHistory>()
                .HasIndex(u => u.IPAddress)
                .IsUnique();
        }
    }
}
