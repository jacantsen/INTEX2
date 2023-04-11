using Microsoft.EntityFrameworkCore;
using INTEX2.Models; 

public class RDSDbContext : DbContext
{
    public RDSDbContext(DbContextOptions<RDSDbContext> options)
        : base(options)
    {
    }

    public DbSet<index2> YourModels { get; set; } // Replace 'YourModel' with the name of a model class representing a table in your RDS PostgreSQL database
    // ... add more DbSet properties for other tables ...
}
