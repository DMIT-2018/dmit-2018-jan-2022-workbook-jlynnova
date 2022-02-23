using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class ControlsModel : PageModel
    {
        [TempData]
        public string Feedback { get; set; }

        [BindProperty]
        public string PasswordText { get; set; }
        [BindProperty]

        public void OnGet()
        {
        }

        public IActionResult OnPostText()
        {
            Feedback = $"Emal {EmailText}"
        }
    }
}
