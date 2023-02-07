using System.Reflection;
using FoodDelivery.Backennd.DAL.Entites;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Backennd.DAL;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
        // Database.EnsureCreated();
    }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    public  DbSet<User> Users { get; set; }
    
    public  DbSet<Role> Roles { get; set; }
    
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetEntryAssembly());
        
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=WIN-HIFI3E1F5E5; Initial Catalog=FoodTest; Integrated Security=true; MultipleActiveResultSets=True;TrustServerCertificate=True");
    }
    
}
