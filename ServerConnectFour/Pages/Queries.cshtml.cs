using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServerConnectFour.Models;
using System.Numerics;

namespace ServerConnectFour.Pages
{
    public class QueriesModel : PageModel
    {
        public IList<User> Users { get; set; } = default!;
        public IList<Game> Games { get; set; } = default!;
        public List<string> Countries { get; set; } = default!;

        private readonly ServerConnectFour.Data.DBContext context;

        public QueriesModel(ServerConnectFour.Data.DBContext context)
        {
            this.context = context;
            Countries = new List<string>
            {
                "United States of America", "Canada", "United Kingdom", "Germany", "France",
                "Italy", "Spain", "India", "China", "Japan", "Brazil", "Australia", "South Africa",
                "Russia", "Mexico", "Argentina", "Egypt", "Saudi Arabia", "Sweden", "Norway",
                "Netherlands", "Belgium", "Switzerland", "Austria", "Greece", "South Korea",
                "Singapore", "Thailand", "New Zealand", "Turkey", "United Arab Emirates",
                "Qatar", "Chile", "Colombia", "Peru", "Vietnam", "Malaysia", "Indonesia",
                "Philippines", "Kenya", "Nigeria", "Morocco", "Algeria", "Tunisia", "Ethiopia", "Ghana"
            };

        }

        public void OnGet()
        {
            Users = context.Users.ToList();
            Games = context.Games.ToList();
        }

    }
}
