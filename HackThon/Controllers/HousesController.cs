using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HackThon.Data;
using HackThon.Models;

namespace HackThon.Controllers
{
    public class HousesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HousesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Houses
        public async Task<IActionResult> Index()
        {
            /*Random random = new Random();
            using (var reader = new StreamReader(@"C:\Users\aiden\Downloads\Telegram Desktop\adresy_pocty_bytov_hack.csv"))
            {
                List<string> names = new List<string>()
                {
                    "Orchard House", "Rose Cottage", "The Hollies", "Oak Barn", "The Willows"
                };
                List<string> types = new List<string>()
                {
                    "Single-family home", "Townhouse", "Modular home", "Tiny home","Condo"
                };
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var values = line.Split(',');
                    int index = random.Next(names.Count);

                    _context.Add(new House
                    {
                        HouseStreet = values[7],
                        HouseNumber = (random.Next(1, 20)).ToString(),
                        HouseType = types[index],
                        HouseArea = values[26],
                        HouseAnimalsAgree = random.Next() > (Int32.MaxValue / 2),
                        HouseSquare = random.Next(30,70),
                        HouseRentType = (random.Next() > (Int32.MaxValue / 2) ? "Rent" : "Buy"),
                        HouseRoomCount = random.Next(1,5),
                        HousePrice = random.Next(100000, 200000),
                        HouseRentPrice = random.Next(300,3000),
                        HouseImg = "https://www.nawy.com/blog/wp-content/uploads/2022/07/House-Interior-Design.jpg",
                        HouseName = names[index]
                    });
                    await _context.SaveChangesAsync();
                }
            }*/
            return View(await _context.Houses.Take(32).ToListAsync());
        }

        // GET: Houses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Houses == null)
            {
                return NotFound();
            }

            var house = await _context.Houses
                .FirstOrDefaultAsync(m => m.HouseId == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // GET: Houses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(House house)
        {
            if (ModelState.IsValid)
            {
                _context.Add(house);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(house);
        }

        // GET: Houses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Houses == null)
            {
                return NotFound();
            }

            var house = _context.Houses.FirstOrDefault(u => u.HouseId == id);
            if (house == null)
            {
                return NotFound();
            }
            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HouseId,HouseName,HousePrice,HouseStreet,HouseNumber,HouseType,HouseArea")] House house)
        {
            if (id != house.HouseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(house);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseExists(house.HouseId))
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
            return View(house);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string searchStr)
        {
            var houses =  _context.Houses.AsEnumerable();
            if (!String.IsNullOrEmpty(searchStr))
            {
                houses = houses.Where(s => s.HouseName.Contains(searchStr));
            }
            return View("Index",await Task.FromResult(houses));
        }
        [HttpPost]
        public async Task<IActionResult> Index(int minPrice,int maxPrice,string typeOfRent,int minSquare, int maxSquare,int minPricePerSquare, int maxPricePerSquare)
        {   
            return View(await _context.Houses.Where(t => t.HousePrice>=minPrice && t.HousePrice<=maxPrice && typeOfRent== t.HouseRentType 
                && t.HouseSquare>=minSquare && t.HouseSquare<=maxPrice).Take(30).ToListAsync());
        }

        // GET: Houses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Houses == null)
            {
                return NotFound();
            }

            var house = await _context.Houses
                .FirstOrDefaultAsync(m => m.HouseId == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Houses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Houses'  is null.");
            }
            var house = await _context.Houses.FindAsync(id);
            if (house != null)
            {
                _context.Houses.Remove(house);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseExists(int id)
        {
          return _context.Houses.Any(e => e.HouseId == id);
        }
    }
}
