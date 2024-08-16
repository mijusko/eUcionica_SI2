using eUcionica.Models;
using eUcionica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eUcionica.Pages.Oblasti
{
    public class MenjanjeOblastiModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public MenjanjeOblastiModel(ApplicationDbContext context)
        {
            this.context = context;
            Predmeti = new List<Predmet>();
            Oblast = new Oblast();
        }

        [BindProperty]
        public Oblast Oblast { get; set; }

        [BindProperty]
        public int NoviPredmetID { get; set; }

        public List<Predmet> Predmeti { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            Oblast = await context.Oblast.FindAsync(id) ?? new Oblast();
            Predmeti = await context.Predmet.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (NoviPredmetID != Oblast.PredmetID)
            {
                Oblast.PredmetID = NoviPredmetID;
            }

            context.Attach(Oblast).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OblastExists(Oblast.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./SpisakOblasti");
        }

        private bool OblastExists(int id)
        {
            return context.Oblast.Any(e => e.ID == id);
        }
    }
}