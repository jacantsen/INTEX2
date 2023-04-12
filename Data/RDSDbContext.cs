using Microsoft.EntityFrameworkCore;
using INTEX2.Models; 

public class RDSDbContext : DbContext
{
    public RDSDbContext(DbContextOptions<RDSDbContext> options)
        : base(options)
    {
    }
    public DbSet<Mummy> Mummies { get; set; }
    public DbSet<Textile> Textiles { get; set; }
    public DbSet<BurialMain_Textile> BurialMain_Textile { get; set; }
    public DbSet<ColorTextile> ColorTextile { get; set; }
    public DbSet<Color> Colors { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mummy>().ToTable("burialmain");
        modelBuilder.Entity<Textile>().ToTable("textile");
        modelBuilder.Entity<Color>().ToTable("color");
        modelBuilder.Entity<BurialMain_Textile>().ToTable("burialmain_textile");
        modelBuilder.Entity<ColorTextile>().ToTable("color_textile");
        // mabye switch color-textile tabel name


        ////might break it. be warned
        //modelBuilder.Entity<Mummy>()
        //   .HasOne(m => m.Textile)
        //   .WithOne(t => t.Mummy)
        //   .HasForeignKey<Textile>(t => t.burialnumber);

        //modelBuilder.Entity<Textile>()
        //    .HasOne(t => t.Color)
        //    .WithOne(c => c.Textile)
        //    .HasForeignKey<Color>(c => c.textileid);

        //new model relationships

        modelBuilder.Entity<BurialMain_Textile>()
       .HasKey(bmt => new { bmt.burialmainid, bmt.textileid });

        modelBuilder.Entity<BurialMain_Textile>()
            .HasOne(bmt => bmt.Mummy)
            .WithMany(m => m.BurialMain_Textile)
            .HasForeignKey(bmt => bmt.burialmainid);

        modelBuilder.Entity<BurialMain_Textile>()
         .HasOne(bmt => bmt.Textile)
         .WithOne(t => t.BurialMain_Textile)
         .HasForeignKey<BurialMain_Textile>(bmt => bmt.textileid);

        modelBuilder.Entity<ColorTextile>()
            .HasKey(ct => new { ct.textileid, ct.colorid });

        modelBuilder.Entity<ColorTextile>()
            .HasOne(ct => ct.Textile)
            .WithOne(t => t.ColorTextile)
            .HasForeignKey<ColorTextile>(ct => ct.textileid);

        modelBuilder.Entity<ColorTextile>()
            .HasOne(ct => ct.Color)
            .WithOne(c => c.ColorTextile)
            .HasForeignKey<ColorTextile>(ct => ct.colorid);



    }
}
