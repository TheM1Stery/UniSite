using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;
using WebApplication2.Data;

namespace WebApplication2.Repository;

public class HistoricalFiguresRepository : IHistoricalFiguresRepository
{
    private readonly HistoryFiguresDbContext _dbContext;

    public HistoricalFiguresRepository(HistoryFiguresDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<HistoricalFigure>> GetFiguresAsync()
    {
        return await _dbContext.HistoricalFigures.ToListAsync();
    }

    public async Task<List<HistoricalFigure>> GetFiguresAsync(int page, int offset = 3)
    {
        var historicalFigures = _dbContext.HistoricalFigures.Skip((page - 1) * offset).Take(offset);
        return await historicalFigures.ToListAsync();
    }

    public async Task<List<HistoricalFigure>> GetFiguresAsync(
        string query,
        int page,
        int offset = 3
    )
    {
        var historicalFigures = _dbContext.HistoricalFigures
            .Where(x => x.Name.Contains(query))
            .Skip((page - 1) * offset)
            .Take(offset);
        return await historicalFigures.ToListAsync();
    }

    public async Task<int> GetNumberOfPagesAsync(int offset = 3)
    {
        return await _dbContext.HistoricalFigures.CountAsync() / offset;
    }

    public async Task<int> GetNumberOfPagesAsync(string query, int offset = 3)
    {
        return await _dbContext.HistoricalFigures
            .Where(x => x.Name.Contains(query))
            .CountAsync() / offset;
    }

    public async Task<OneOf<HistoricalFigure, NotFound>> GetFigureAsync(Guid id)
    {
        var figure = await _dbContext.HistoricalFigures.FindAsync(id);

        if (figure is null)
            return new NotFound();

        return figure;
    }

    public async Task<OneOf<HistoricalFigure, Error>> AddFigureAsync(HistoricalFigure figure)
    {
        var entity = await _dbContext.AddAsync(figure);

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            return new Error();
        }

        return entity.Entity;
    }

    public async Task<bool> FigureExistsAsync(Guid id)
    {
        return await _dbContext.HistoricalFigures.AnyAsync(x => x.Id == id);
    }
}
