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

    public async Task<OneOf<HistoricalFigure, NotFound, Error>> UpdateFigureAsync(HistoricalFigure figure)
    {
        try
        {
            var updatedEntity = _dbContext.HistoricalFigures.Update(figure);
            await _dbContext.SaveChangesAsync();
            return updatedEntity.Entity;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return new NotFound();
        }
        catch (Exception)
        {
            return new Error();
        }
    }

    public async Task<OneOf<Success, NotFound>> DeleteFigureAsync(Guid id)
    {
        var rows = await _dbContext.HistoricalFigures.Where(x => x.Id == id)
            .ExecuteDeleteAsync();
        return rows > 0 ? new Success() : new NotFound();
    }

    public async Task<bool> FigureExistsAsync(Guid id)
    {
        return await _dbContext.HistoricalFigures.AnyAsync(x => x.Id == id);
    }
}