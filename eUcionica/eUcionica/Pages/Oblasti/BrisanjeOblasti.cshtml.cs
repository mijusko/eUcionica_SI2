using eUcionica.Models;
using eUcionica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eUcionica.Pages.Oblasti
{
    public class BrisanjeOblastiModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public BrisanjeOblastiModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        [BindProperty]
        public Oblast? Oblast { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Oblast = await context.Oblast.Include(o => o.Predmet).FirstOrDefaultAsync(m => m.ID == id);

            if (Oblast == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oblast = await context.Oblast.FindAsync(id);

            if (oblast != null)
            {
                context.Oblast.Remove(oblast);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./SpisakOblasti");
        }
    }
}

