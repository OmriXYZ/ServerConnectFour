using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServerConnectFour.Data;
using ServerConnectFour.Models;

namespace ServerConnectFour.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly ServerConnectFour.Data.DBContext _context;

        public IndexModel(ServerConnectFour.Data.DBContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Users != null)
            {
                User = await _context.Users.ToListAsync();
            }
        }
    }
}
