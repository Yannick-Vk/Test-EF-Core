using Microsoft.EntityFrameworkCore;

namespace Test_Ef.Models;

public class LandContext : DbContext {
    public DbSet<Land> Landen { get; set; }
    public DbSet<Stad> Steden { get; set; }
    public DbSet<Taal> Talen  { get; set; }
    
}