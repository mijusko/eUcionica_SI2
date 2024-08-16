using eUcionica.Models;
using eUcionica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eUcionica.Pages.Predmeti
{
    public class DodavanjePredmetaModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public DodavanjePredmetaModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Predmet Predmet { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            if (context.Predmet == null || Predmet == null)
            {
                return Page();
            }

            context.Predmet.Add(Predmet);
            await context.SaveChangesAsync();

            return RedirectToPage("./SpisakPredmeta");
        }
    }
}