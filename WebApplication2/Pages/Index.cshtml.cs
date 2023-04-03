using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Repository;

namespace WebApplication2.Pages;

public class Index : PageModel
{
    private readonly IHistoricalFiguresRepository _repository;

    public List<HistoricalFigure> Figures { get; private set; } = new();


    [FromQuery] public int PageNo { get; private set; }

    public int PageCount { get; private set; }

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
}