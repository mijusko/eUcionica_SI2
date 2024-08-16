using eUcionica.Models;
using eUcionica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eUcionica.Pages.Predmeti
{
    public class BrisanjePredmetaModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public BrisanjePredmetaModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        [BindProperty]
        public Predmet Predmet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Predmet == null)
            {
                return NotFound();
            }

            var predmet = await context.Predmet.FirstOrDefaultAsync(m => m.ID == id);

            if (predmet == null)
            {
                return NotFound();
            }
            else
            {
                Predmet = predmet;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || context.Predmet == null)
            {
                return NotFound();
            }
            var predmet = await context.Predmet.FindAsync(id);

            if (predmet != null)
            {
                Predmet = predmet;
                context.Predmet.Remove(Predmet);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./SpisakPredmeta");
        }
    }
}