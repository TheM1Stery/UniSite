using OneOf;
using OneOf.Types;
using WebApplication2.Data;

namespace WebApplication2.Repository;

public interface IHistoricalFiguresRepository
{
    public Task<List<HistoricalFigure>> GetFiguresAsync();

    public Task<List<HistoricalFigure>> GetFiguresAsync(int page, int offset = 3);
    
    public Task<int> GetNumberOfPagesAsync(int offset = 3);

    public Task<OneOf<HistoricalFigure, NotFound>> GetFigureAsync(Guid id);

    public Task<OneOf<HistoricalFigure,Error>> AddFigureAsync(HistoricalFigure figure);

    public Task<OneOf<HistoricalFigure, NotFound, Error>> UpdateFigureAsync(HistoricalFigure figure);

    public Task<OneOf<Success, NotFound>> DeleteFigureAsync(Guid id);

    public Task<bool> FigureExistsAsync(Guid id);
    
}