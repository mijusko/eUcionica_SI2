using eUcionica.Models;
using eUcionica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace eUcionica.Pages.Testovi
{
    public class TestZnanjaModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public TestZnanjaModel(ApplicationDbContext context)
        {
            this.context = context;
            SelectedQuestions = new List<Pitanje>();
        }

        public List<Pitanje>? SelectedQuestions { get; set; }

        public void OnGet()
        {
            var selectedQuestionsJson = TempData["SelectedQuestions"] as string;
            if (selectedQuestionsJson != null)
            {
                SelectedQuestions = JsonConvert.DeserializeObject<List<Pitanje>>(selectedQuestionsJson);
            }
            else
            {
                SelectedQuestions = new List<Pitanje>();
            }
        }
    }
}
