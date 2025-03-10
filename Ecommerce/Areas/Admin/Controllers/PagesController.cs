using Ecommerce.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;
        public async Task<IActionResult> Index()
        {
            List<Page> pages = await _context.Pages.ToListAsync();
            return View(pages);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                var slug = await _context.Pages.FirstOrDefaultAsync(a => a.Slug == page.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "That page already exists!");
                    return View(page);
                }
                _context.Add(page);
                await _context.SaveChangesAsync();
                TempData["success"] = "The page has been added";
                return RedirectToAction("Index");
            }

            return View(page);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Page page = await _context.Pages.FindAsync(id);
            if (page == null) { return NotFound(); }

            return View(page);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Id == 1 ? "home" : page.Title.ToLower().Replace(" ", "-");
                var slug = await _context.Pages.FirstOrDefaultAsync(a =>
                a.Slug == page.Slug && a.Id != page.Id);
                if (slug != null)
                {
                    ModelState.AddModelError("", "That page already exists!");
                    return View(page);
                }
                _context.Update(page);
                await _context.SaveChangesAsync();
                TempData["success"] = "The page has been Edited";
                //return RedirectToAction("Index");
            }

            return View(page);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Page page = await _context.Pages.FindAsync(id);
            if (page == null || page.Id == 1)
            {
                TempData["error"] = "The page doesn't exist";
            }
            else
            {
                _context.Pages.Remove(page);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
