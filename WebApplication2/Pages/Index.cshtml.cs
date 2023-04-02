using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Repository;

namespace WebApplication2.Pages;

public class Index : PageModel
{
    private readonly IHistoricalFiguresRepository _repository;

    public List<HistoricalFigure> Figures { get; private set; } = new();


    public Index(IHistoricalFiguresRepository repository)
    {
        _repository = repository;
    }

    public async Task OnGet()
    {
        Figures = await _repository.GetFiguresAsync();
    }
}