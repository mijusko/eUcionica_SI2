using eUcionica.Models;
using eUcionica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace eUcionica.Pages.Pitanja
{
    public class KreiranjePitanjaModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public KreiranjePitanjaModel(ApplicationDbContext context)
        {
            this.context = context;
            Predmeti = new List<Predmet>();
            Oblasti = new List<Oblast>();
            NovoPitanje = new Pitanje();
            NoviPredmetID = 0;
            NovaOblastID = 0;
        }
        [BindProperty]
        public Pitanje NovoPitanje { get; set; }

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

        public void OnGet()
        {
            Predmeti = context.Predmet.ToList();
        }

        public JsonResult OnGetOblastiByPredmet(int predmetId)
        {
            var oblasti = context.Oblast.Where(o => o.PredmetID == predmetId).ToList();
            return new JsonResult(oblasti);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            NovoPitanje.PredmetID = NoviPredmetID;
            NovoPitanje.OblastID = NovaOblastID;


            context.Pitanje.Add(NovoPitanje);
            await context.SaveChangesAsync();

            return RedirectToPage("./SpisakPitanja");
        }
    }
}