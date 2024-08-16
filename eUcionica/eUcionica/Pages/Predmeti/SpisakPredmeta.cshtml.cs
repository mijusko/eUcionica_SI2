using eUcionica.Models;
using eUcionica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eUcionica.Pages.Predmeti
{
    public class SpisakPredmetaModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public SpisakPredmetaModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<Predmet> Predmet { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (context.Predmet != null)
            {
                Predmet = await context.Predmet.ToListAsync();
            }
        }
    }
}
