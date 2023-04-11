using Microsoft.EntityFrameworkCore;
using INTEX2.Models; 

public class RDSDbContext : DbContext
{
    public RDSDbContext(DbContextOptions<RDSDbContext> options)
        : base(options)
    {
    }
    public DbSet<Mummy> Mummies { get; set; } 
}
