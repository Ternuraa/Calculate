using Calculate.Models;
using Microsoft.EntityFrameworkCore;
public class ApplicationContext : DbContext
{
    public DbSet<History> History => Set<History>();
    public ApplicationContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
}
