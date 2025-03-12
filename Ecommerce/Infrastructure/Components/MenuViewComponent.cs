using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce.Infrastructure.Components
{
    public class MenuViewComponent(DataContext dataContext) :ViewComponent
    {
        private readonly DataContext _context=dataContext;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Pages.Where(a=>a.Slug!="home").OrderBy(a=>a.Order).ToListAsync());
        }
    }
}
