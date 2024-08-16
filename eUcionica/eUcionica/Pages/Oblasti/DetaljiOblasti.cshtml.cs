using eUcionica.Models;
using eUcionica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eUcionica.Pages.Oblasti
{
    public class DetaljiOblastiModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public DetaljiOblastiModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Oblast? Oblast { get; set; }
        public List<Pitanje>? Pitanja { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Oblast = await context.Oblast
                .Include(o => o.Predmet)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Oblast == null)
            {
                return NotFound();
            }

            Pitanja = await context.Pitanje
                .Where(p => p.OblastID == id)
                .ToListAsync();

            return Page();
        }
    }
}
