using eUcionica.Models;
using eUcionica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eUcionica.Pages.Oblasti
{
    public class DodavanjeOblastiModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public DodavanjeOblastiModel(ApplicationDbContext context)
        {
            this.context = context;
            NewOblast = new Oblast();
        }

        [BindProperty]
        public Oblast NewOblast { get; set; }

        public List<Predmet> Predmeti { get; set; } = new List<Predmet>();

        public void OnGet()
        {
            Predmeti = context.Predmet.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Predmeti = context.Predmet.ToList();
                return Page();
            }

            context.Oblast.Add(NewOblast);
            await context.SaveChangesAsync();

            return RedirectToPage("./SpisakOblasti");
        }
    }
}