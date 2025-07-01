using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Test_Ef.Models;

public class LandContext : DbContext {
    public static IConfigurationRoot config;
    
    public DbSet<Land> Landen { get; set; }
    public DbSet<Stad> Steden { get; set; }
    public DbSet<Taal> Talen  { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)?.FullName)
            .AddJsonFile("appsettings.json", false).Build();
        var connectionString =
            config.GetConnectionString("Landen");
        if (connectionString != null)
            optionsBuilder.UseSqlServer(connectionString,
                options => options.MaxBatchSize(150));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Land>()
            .HasMany(l => l.Talen)
            ;
        modelBuilder.Entity<Stad>().HasOne(s => s.Land);
        
        modelBuilder.Entity<Taal>().HasMany(t => t.Landen);
    }
}