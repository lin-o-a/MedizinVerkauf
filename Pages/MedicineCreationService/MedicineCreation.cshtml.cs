using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MedizinVerkauf.Models;
using MedizinVerkauf.DomainLogic;

namespace MedizinVerkauf.Pages
{
    public class MedicineCreationModel : PageModel
    {
        private readonly AppDbContext _context;

        public MedicineCreationModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Medicine Medicine { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Medicine.Add(Medicine);
            _context.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}
