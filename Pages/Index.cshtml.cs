using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MedizinVerkauf.Models;
using Microsoft.EntityFrameworkCore;
using MedizinVerkauf.DomainLogic;
using MedizinVerkauf.Models;
using Microsoft.EntityFrameworkCore;
using MedizinVerkauf.DomainLogic;

namespace MedizinVerkauf.Pages
{
namespace MedizinVerkauf.Pages
{

public class IndexModel : PageModel
{
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _context;
        public IndexModel(ILogger<IndexModel> logger, AppDbContext context) {
            _logger = logger;
            _context = context;
        }
        public string Message { get; private set; } = "...VeryNew";
        public IList<Medicine> Medicine { get; set; }

        public async Task OnGetAsync() {
            Medicine = await _context.Medicine.ToListAsync();
        }
    }
}