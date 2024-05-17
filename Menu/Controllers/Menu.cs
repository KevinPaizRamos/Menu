using Microsoft.AspNetCore.Mvc;
using Menu.Data;
using Menu.Models;
using Microsoft.EntityFrameworkCore;
namespace Menu.Controllers
{
    public class Menu : Controller
    {
        private readonly MenuContext _context;
        public Menu(MenuContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString)
        { 
            var dishes = from d in _context.Dishes
                       select d;
            if (!String.IsNullOrEmpty(searchString))
                {
                dishes = dishes.Where(d => d.name.Contains(searchString));
                return View(await dishes.ToListAsync());
            }
            return View(await dishes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dish = await _context.Dishes
                .Include(di => di.DishIngredient)
                .ThenInclude(i => i.Ingrident)
                .FirstOrDefaultAsync(d => d.id == id);
            if (dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }
    }
}
