using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data;

public class HistoryFiguresDbContext : DbContext
{
    public HistoryFiguresDbContext(DbContextOptions<HistoryFiguresDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HistoricalFigure>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            e.Property(x => x.Name).IsRequired();
            e.Property(x => x.Surname).IsRequired();
            e.Property(x => x.Occupation).IsRequired();
            e.Property(x => x.DateOfBirth).IsRequired();
            e.Property(x => x.DateOfDeath).IsRequired();
            e.Property(x => x.Description).IsRequired();
        });
    }


    public DbSet<HistoricalFigure> HistoricalFigures { get; set; } = null!;
}