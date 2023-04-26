using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Repository;

namespace WebApplication2.Pages;

public class Index : PageModel
{
    private readonly IHistoricalFiguresRepository _repository;

    public List<HistoricalFigure> Figures { get; private set; } = new();

    public int PageNo { get; private set; }

    public int PageCount { get; private set; }

    public string? Query { get; private set; }

    public Index(IHistoricalFiguresRepository repository)
    {
        _repository = repository;
    }

    public async Task OnGet(int pageNo)
    {
        PageCount = await _repository.GetNumberOfPagesAsync();
        if (pageNo == 0)
        {
            Figures = await _repository.GetFiguresAsync(1);
            PageNo = 1;
            return;
        }
        Figures = await _repository.GetFiguresAsync(pageNo);
        PageNo = pageNo;
    }

    public async Task OnGetSearch(string? query, int pageNo)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            await OnGet(pageNo);
            return;
        }
        PageCount = await _repository.GetNumberOfPagesAsync(query);
        if (pageNo == 0)
        {
            Figures = await _repository.GetFiguresAsync(query, 1);
            PageNo = 1;
            Query = query;
            return;
        }
        Figures = await _repository.GetFiguresAsync(query, pageNo);
        PageNo = pageNo;
        Query = query;
    }
}
