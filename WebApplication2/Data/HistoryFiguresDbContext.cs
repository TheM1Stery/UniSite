using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data;

public class HistoryFiguresDbContext : DbContext
{
    public HistoryFiguresDbContext(DbContextOptions<HistoryFiguresDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }


    public DbSet<HistoricalFigure> HistoricalFigures { get; set; } = null!;

    
}