using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Repository;

namespace WebApplication2.Pages
{
    public class PostModel : PageModel
    {
        private readonly IHistoricalFiguresRepository _repository;
        
        public HistoricalFigure? Figure { get; set; }
       

        public PostModel(IHistoricalFiguresRepository repository)
        {
            _repository = repository;
        }
        
        public async Task OnGet(Guid id)
        {
            var result = await _repository.GetFigureAsync(id);
            result.Switch(
                x => Figure = x,
                nf => Figure = null
            );
        }
        
        
        
    }
}
