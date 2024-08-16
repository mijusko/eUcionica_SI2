using eUcionica.Models;
using eUcionica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace eUcionica.Pages.Testovi
{
    public class GenerisanjeTestaModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public GenerisanjeTestaModel(ApplicationDbContext context)
        {
            this.context = context;
            SelectedPredmetID = 0;
            SelectedOblastID = 0;
            SelectedNivoTezine = "Svi";
        }

        [BindProperty(SupportsGet = true)]
        public int SelectedPredmetID { get; set; }

        [BindProperty]
        public Pitanje Pitanje { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int SelectedOblastID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedNivoTezine { get; set; }

        public SelectList PredmetOptions { get; set; } = new SelectList(new List<SelectListItem>());
        public SelectList OblastOptionsWithAll { get; set; } = new SelectList(new List<SelectListItem>());
        public SelectList NivoTezineOptions { get; set; } = new SelectList(new List<SelectListItem>());

        public List<Pitanje> SelectedQuestions { get; set; } = new List<Pitanje>();

        public void OnGet()
        {
            PredmetOptions = new SelectList(context.Predmet, "ID", "NazivPredmeta");

            var oblastsWithAll = context.Oblast
                .Where(o => o.PredmetID == SelectedPredmetID)
                .Select(o => new SelectListItem { Value = o.ID.ToString(), Text = o.Name })
                .ToList();
            oblastsWithAll.Insert(0, new SelectListItem { Value = "0", Text = "Sve oblasti" });
            OblastOptionsWithAll = new SelectList(oblastsWithAll, "Value", "Text");

            NivoTezineOptions = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "Lako", Text = "Lako" },
                new SelectListItem { Value = "Srednje", Text = "Srednje" },
                new SelectListItem { Value = "Tesko", Text = "Tesko" },
                new SelectListItem { Value = "Svi", Text = "Svi nivoi" }
            }, "Value", "Text");
        }

        public JsonResult OnGetOblasts(int predmetID)
        {
            var oblasts = context.Oblast
                .Where(o => o.PredmetID == predmetID)
                .Select(o => new { id = o.ID, name = o.Name })
                .ToList();

            return new JsonResult(oblasts);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            IQueryable<Pitanje> query = context.Pitanje
                .Where(p => p.PredmetID == SelectedPredmetID);

            if (SelectedOblastID != 0)
            {
                query = query.Where(p => p.OblastID == SelectedOblastID);
            }

            if (SelectedNivoTezine != "Svi")
            {
                query = query.Where(p => p.NivoTezine == SelectedNivoTezine);
            }

            List<Pitanje> pitanja = await query.ToListAsync();

            var random = new Random();
            SelectedQuestions = pitanja.OrderBy(q => random.Next()).Take(5).ToList();
            TempData["SelectedQuestions"] = JsonConvert.SerializeObject(SelectedQuestions);
            return RedirectToPage("./TestZnanja");
        }
    }
}
