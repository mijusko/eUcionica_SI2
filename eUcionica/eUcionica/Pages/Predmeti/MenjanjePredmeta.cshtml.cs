using eUcionica.Models;
using eUcionica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eUcionica.Pages.Predmeti
{
    public class MenjanjePredmetaModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public MenjanjePredmetaModel(ApplicationDbContext context)
        {
            this.context = context;
            Predmet = new Predmet();
        }

        [BindProperty]
        public Predmet Predmet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Predmet = await context.Predmet.FirstOrDefaultAsync(m => m.ID == id) ?? new Predmet();

            if (Predmet == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Attach(Predmet).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredmetExists(Predmet.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./SpisakPredmeta");
        }

        private bool PredmetExists(int id)
        {
            return context.Predmet.Any(e => e.ID == id);
        }
    }
}
