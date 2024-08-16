using eUcionica.Models;
using eUcionica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace eUcionica.Pages.Pitanja
{
    public class MenjanjePitanjaModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public MenjanjePitanjaModel(ApplicationDbContext context)
        {
            this.context = context;
            Predmeti = new List<Predmet>();
            Pitanje = new Pitanje();
            Oblasti = new List<Oblast>();
        }


        [BindProperty]
        public Pitanje Pitanje { get; set; }

        [BindProperty]
        public int NoviPredmetID { get; set; }

        [BindProperty]
        public int NovaOblastID { get; set; }

        [BindProperty]
        public string? PitanjeText { get; set; }

        [BindProperty]
        public string? TacanOdgovor { get; set; }

        public List<Predmet> Predmeti { get; set; }

        public List<Oblast> Oblasti { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pitanje = await context.Pitanje.FindAsync(id) ?? new Pitanje();

            if (Pitanje == null)
            {
                return NotFound();
            }


            Predmeti = await context.Predmet.ToListAsync();
            Oblasti = await context.Oblast.ToListAsync();


            NoviPredmetID = Pitanje.PredmetID;
            NovaOblastID = Pitanje.OblastID;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            Predmeti = await context.Predmet.ToListAsync();
            Oblasti = await context.Oblast.ToListAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (NoviPredmetID != Pitanje.PredmetID)
            {
                Pitanje.PredmetID = NoviPredmetID;
            }

            if (NovaOblastID != Pitanje.OblastID)
            {
                Pitanje.OblastID = NovaOblastID;
            }


            context.Attach(Pitanje).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PitanjeExists(Pitanje.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./SpisakPitanja");
        }

        private bool PitanjeExists(int id)
        {
            return context.Pitanje.Any(e => e.ID == id);
        }
    }
}
