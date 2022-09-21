using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace InterviewTestTask.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Delay is required")]
        [Range(1, ushort.MaxValue, ErrorMessage = "Delay must be between 1 and 65,535 ms.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Delay must be numeric value")]
        public ushort Delay { get; set; } = 1;

        public void OnGet()
        {
        }
    }
}