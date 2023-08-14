using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServerConnectFour.Data;
using ServerConnectFour.Models;

namespace ServerConnectFour.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly ServerConnectFour.Data.DBContext _context;

        [BindProperty]
        public User User { get; set; } = default!;
        public List<SelectListItem> countries;

        public CreateModel(ServerConnectFour.Data.DBContext context)
        {
            _context = context;
            countries = new List<SelectListItem>()
            {
                new SelectListItem { Value = "USA", Text = "United States of America" },
                new SelectListItem { Value = "Canada", Text = "Canada" },
                new SelectListItem { Value = "UK", Text = "United Kingdom" },
                new SelectListItem { Value = "Germany", Text = "Germany" },
                new SelectListItem { Value = "France", Text = "France" },
                new SelectListItem { Value = "Italy", Text = "Italy" },
                new SelectListItem { Value = "Spain", Text = "Spain" },
                new SelectListItem { Value = "India", Text = "India" },
                new SelectListItem { Value = "China", Text = "China" },
                new SelectListItem { Value = "Japan", Text = "Japan" },
                new SelectListItem { Value = "Brazil", Text = "Brazil" },
                new SelectListItem { Value = "Australia", Text = "Australia" },
                new SelectListItem { Value = "South Africa", Text = "South Africa" },
                new SelectListItem { Value = "Russia", Text = "Russia" },
                new SelectListItem { Value = "Mexico", Text = "Mexico" },
                new SelectListItem { Value = "Argentina", Text = "Argentina" },
                new SelectListItem { Value = "Egypt", Text = "Egypt" },
                new SelectListItem { Value = "Saudi Arabia", Text = "Saudi Arabia" },
                new SelectListItem { Value = "Sweden", Text = "Sweden" },
                new SelectListItem { Value = "Norway", Text = "Norway" },
                new SelectListItem { Value = "Netherlands", Text = "Netherlands" },
                new SelectListItem { Value = "Belgium", Text = "Belgium" },
                new SelectListItem { Value = "Switzerland", Text = "Switzerland" },
                new SelectListItem { Value = "Austria", Text = "Austria" },
                new SelectListItem { Value = "Greece", Text = "Greece" },
                new SelectListItem { Value = "South Korea", Text = "South Korea" },
                new SelectListItem { Value = "Singapore", Text = "Singapore" },
                new SelectListItem { Value = "Thailand", Text = "Thailand" },
                new SelectListItem { Value = "New Zealand", Text = "New Zealand" },
                new SelectListItem { Value = "Turkey", Text = "Turkey" },
                new SelectListItem { Value = "UAE", Text = "United Arab Emirates" },
                new SelectListItem { Value = "Qatar", Text = "Qatar" },
                new SelectListItem { Value = "Chile", Text = "Chile" },
                new SelectListItem { Value = "Colombia", Text = "Colombia" },
                new SelectListItem { Value = "Peru", Text = "Peru" },
                new SelectListItem { Value = "Vietnam", Text = "Vietnam" },
                new SelectListItem { Value = "Malaysia", Text = "Malaysia" },
                new SelectListItem { Value = "Indonesia", Text = "Indonesia" },
                new SelectListItem { Value = "Philippines", Text = "Philippines" },
                new SelectListItem { Value = "Kenya", Text = "Kenya" },
                new SelectListItem { Value = "Nigeria", Text = "Nigeria" },
                new SelectListItem { Value = "Egypt", Text = "Egypt" },
                new SelectListItem { Value = "Morocco", Text = "Morocco" },
                new SelectListItem { Value = "Algeria", Text = "Algeria" },
                new SelectListItem { Value = "Tunisia", Text = "Tunisia" },
                new SelectListItem { Value = "Ethiopia", Text = "Ethiopia" },
                new SelectListItem { Value = "Ghana", Text = "Ghana" }
            };

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Users.Any(user => user.ID == User.ID))
            {
                ModelState.AddModelError("ID_ERROR", "ID already exists");
                return Page();
            }
            if (!ModelState.IsValid || _context.Users == null || User == null)
            {
                return Page();
            }



            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
