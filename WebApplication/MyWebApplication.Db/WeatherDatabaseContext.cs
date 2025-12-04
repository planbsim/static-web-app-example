using Microsoft.EntityFrameworkCore;

namespace MyWebApplication.Db;

public class WeatherDatabaseContext : DbContext
{
    public WeatherDatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected WeatherDatabaseContext()
    {
    }

    public virtual DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer("Server=tcp:sql-server-plans.database.windows.net,1433;Initial Catalog=sql-database-plans;Persist Security Info=False;User ID=plans;Password=1DHzdscie2ruNWnsQEKm;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
}
