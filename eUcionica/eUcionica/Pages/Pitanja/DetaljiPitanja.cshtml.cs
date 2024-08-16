using eUcionica.Models;
using eUcionica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eUcionica.Pages.Pitanja
{
    public class DetaljiPitanjaModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public DetaljiPitanjaModel(ApplicationDbContext context)
        {
            this.context = context;
            Pitanje = null;
        }

        public Pitanje? Pitanje { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pitanje = await context.Pitanje
                .Include(p => p.Predmet)
                .Include(p => p.Oblast)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Pitanje == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
