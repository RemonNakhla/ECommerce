using Ecommerce.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.Controllers
{
    public class PagesController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;
        public async Task<IActionResult>  Index(string slug="")
        {
            slug = slug.IsNullOrEmpty() ? "home" : slug; 
            var page = await _context.Pages.Where(a => a.Slug == slug).FirstOrDefaultAsync();
            if (page == null) { return NotFound(); }
            return View(page);
        }
        //https://github.com/fep-coder/aspcoremvccmsecommerce
    }
}
