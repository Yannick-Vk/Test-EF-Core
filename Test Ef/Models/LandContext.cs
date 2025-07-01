using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Test_Ef.Models;

public class LandContext : DbContext {
    public static IConfigurationRoot config;

    public DbSet<Land> Landen { get; set; }
    public DbSet<Stad> Steden { get; set; }
    public DbSet<Taal> Talen { get; set; }

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
            .HasMany(land => land.Talen)
            .WithMany(taal => taal.Landen)
            .UsingEntity(j => {
                j.ToTable("LandenTalen");
                j.Property("LandenLandCode").HasColumnName("LandCode");
                j.Property("TalenTaalCode").HasColumnName("TaalCode");
            })
            ;

        modelBuilder.Entity<Land>()
            .HasMany(land => land.Talen)
            .WithMany(taal => taal.Landen)
            .UsingEntity(j =>
                j.HasData(
                    new { LandenLandCode = "BEL", TalenTaalCode = "de" },
                    new { LandenLandCode = "BEL", TalenTaalCode = "fr" },
                    new { LandenLandCode = "BEL", TalenTaalCode = "nl" },
                    new { LandenLandCode = "DEU", TalenTaalCode = "de" },
                    new { LandenLandCode = "FRA", TalenTaalCode = "fr" },
                    new { LandenLandCode = "LUX", TalenTaalCode = "de" },
                    new { LandenLandCode = "LUX", TalenTaalCode = "fr" },
                    new { LandenLandCode = "LUX", TalenTaalCode = "lb" },
                    new { LandenLandCode = "NLD", TalenTaalCode = "nl" }
                )
            );

        modelBuilder.Entity<Stad>()
            .HasOne(s => s.Land)
            .WithMany(l => l.Steden)
            .HasForeignKey(s => s.LandCode);

        modelBuilder.Entity<Land>().HasData([
            new Land { LandCode = "BEL", Naam = "Belgie" },
            new Land { LandCode = "DEU", Naam = "Duitsland" },
            new Land { LandCode = "FRA", Naam = "Frankrijk" },
            new Land { LandCode = "LUX", Naam = "Luxemburg" },
            new Land { LandCode = "NLD", Naam = "Nederland" },
        ]);

        modelBuilder.Entity<Taal>().HasData([
            new Taal { TaalCode = "de", Naam = "Duits" },
            new Taal { TaalCode = "fr", Naam = "Frans" },
            new Taal { TaalCode = "lb", Naam = "Luxemburgs" },
            new Taal { TaalCode = "nl", Naam = "Nederlands" },
        ]);

        modelBuilder.Entity<Stad>().HasData([
            new Stad { StadNummer = 1, Naam = "Brussel", LandCode = "BEL" },
            new Stad { StadNummer = 2, Naam = "Antwerpen", LandCode = "BEL" },
            new Stad { StadNummer = 3, Naam = "Luik", LandCode = "BEL" },
            new Stad { StadNummer = 4, Naam = "Amsterdam", LandCode = "NLD" },
            new Stad { StadNummer = 5, Naam = "Den Haag", LandCode = "NLD" },
            new Stad { StadNummer = 6, Naam = "Rotterdam", LandCode = "NLD" },
            new Stad { StadNummer = 7, Naam = "Berlijn", LandCode = "DEU" },
            new Stad { StadNummer = 8, Naam = "Hamburg", LandCode = "DEU" },
            new Stad { StadNummer = 9, Naam = "Munchen", LandCode = "DEU" },
            new Stad { StadNummer = 10, Naam = "Luxemburg", LandCode = "LUX" },
            new Stad { StadNummer = 11, Naam = "Parijs", LandCode = "FRA" },
            new Stad { StadNummer = 12, Naam = "Marseille", LandCode = "FRA" },
            new Stad { StadNummer = 13, Naam = "Lyon", LandCode = "FRA" }
        ]);
    }
}