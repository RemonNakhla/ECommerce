using Ecommerce.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;
        public async Task<IActionResult>  Index()
        {
            List<Page> pages = await _context.Pages.ToListAsync();            
            return View(pages);
        }
    }
}
