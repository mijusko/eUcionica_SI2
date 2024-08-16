using eUcionica.Models;
using eUcionica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eUcionica.Pages.Pitanja
{
    public class SpisakPitanjaModel : PageModel
    {
        private readonly ApplicationDbContext context;

        [BindProperty(SupportsGet = true)]
        public string? SearchText { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Sort { get; set; }

        public SpisakPitanjaModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IList<Pitanje>? Pitanje { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Pitanje> pitanjeQuery = context.Pitanje
                .Include(p => p.Oblast)
                .Include(p => p.Predmet);

            if (!string.IsNullOrEmpty(SearchText))
            {
                pitanjeQuery = pitanjeQuery.Where(p =>
                    p.Predmet != null && p.Oblast != null && p.NivoTezine != null &&
                    p.Predmet.NazivPredmeta != null && p.Oblast.Name != null &&
                    (EF.Functions.Like(p.Predmet.NazivPredmeta, $"%{SearchText}%") ||
                    EF.Functions.Like(p.Oblast.Name, $"%{SearchText}%") ||
                    EF.Functions.Like(p.NivoTezine, $"%{SearchText}%")));
            }
            if (Sort == "oblast")
            {
                pitanjeQuery = pitanjeQuery.OrderBy(p => p.Oblast != null ? p.Oblast.Name : null);
            }
            else if (Sort == "predmet")
            {
                pitanjeQuery = pitanjeQuery.OrderBy(p => p.Predmet != null ? p.Predmet.NazivPredmeta : null);
            }
            else if (Sort == "tezina")
            {
                pitanjeQuery = pitanjeQuery.OrderBy(p => p.NivoTezine);
            }

            Pitanje = await pitanjeQuery.ToListAsync();
        }

        public async Task OnPostAsync()
        {
            IQueryable<Pitanje> pitanjeQuery = context.Pitanje
                .Include(p => p.Oblast)
                .Include(p => p.Predmet);

            if (!string.IsNullOrEmpty(SearchText))
            {
                pitanjeQuery = pitanjeQuery.Where(p =>
                    p.Predmet != null && p.Oblast != null && p.NivoTezine != null &&
                    p.Predmet.NazivPredmeta != null && p.Oblast.Name != null &&
                    (EF.Functions.Like(p.Predmet.NazivPredmeta, $"%{SearchText}%") ||
                    EF.Functions.Like(p.Oblast.Name, $"%{SearchText}%") ||
                    EF.Functions.Like(p.NivoTezine, $"%{SearchText}%")));
            }

            Pitanje = await pitanjeQuery.ToListAsync();
        }
    }
}