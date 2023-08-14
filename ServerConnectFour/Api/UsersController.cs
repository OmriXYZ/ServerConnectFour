using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServerConnectFour.Data;
using ServerConnectFour.Models;

namespace ServerConnectFour.Api
{
    public class UsersController : Controller
    {
        private readonly DBContext _context;
        private Random _random;

        public UsersController(DBContext context)
        {
            _context = context;
            _random = new Random();
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
              return _context.Users != null ? 
                          View(await _context.Users.ToListAsync()) :
                          Problem("Entity set 'DBContext.Users'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Phone,Country")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Phone,Country")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'DBContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.Users?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        [HttpGet("login/{id}")]
        public async Task<ActionResult> Login(int id)
        {
            if (_context.Users == null || !UserExists(id))
            {
                return NotFound();
            }
            var user = _context.Users.FindAsync(id);
            return Ok(user.Result.Name);
        }
        public class UserID
        {
            public int jID { get; set; }
        }
        public class EndGame
        {
            public string gameID { get; set; }
            public bool userWin { get; set; }

        }
        [HttpPost("initgame/")]
        public async Task<ActionResult> InitGame([FromBody] UserID ID)
        {

            int id = ID.jID;
            if (!UserExists(id))
                return BadRequest("ID not found");

            Game game = new Game
            {
                PlayerID = id,
            };
            DateTime currentUtcDateTime = DateTime.UtcNow;
            TimeZoneInfo israelTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Israel Standard Time");
            DateTime israelDateTime = TimeZoneInfo.ConvertTimeFromUtc(currentUtcDateTime, israelTimeZone);
            game.GameDate = israelDateTime;
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return Ok(game.ID);
        }
        [HttpPost("terminategame/")]
        public async Task<ActionResult> TerminateGame([FromBody] EndGame endGame)
        {
            DateTime currentUtcDateTime = DateTime.UtcNow;
            // Define the Israel Standard Time zone
            TimeZoneInfo israelTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Israel Standard Time");
            // Convert the UTC time to Israel's local time
            DateTime israelDateTime = TimeZoneInfo.ConvertTimeFromUtc(currentUtcDateTime, israelTimeZone);
            Game game = _context.Games.Find(int.Parse(endGame.gameID));
            game.Duration = israelDateTime - game.GameDate;
            game.PlayerWin = endGame.userWin;
            await _context.SaveChangesAsync();
            return Ok("Game end successfuly");
        }

        [HttpGet("step/")]
        public async Task<ActionResult> Step()
        {
            int rand_column = _random.Next(0, 7);
            return Ok(rand_column);
        }
    }
}
