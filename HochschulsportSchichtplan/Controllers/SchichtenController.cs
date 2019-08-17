using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HochschulsportSchichtplan.Models;
using Microsoft.IdentityModel;
using HochschulsportSchichtplan.Data;

namespace HochschulsportSchichtplan.Controllers
{
    public class SchichtenController : Controller
    {
        private const long V = 36000000000;
        private readonly HochschulsportSchichtplanContext _context;

       

        public SchichtenController(HochschulsportSchichtplanContext context)
        {
            _context = context;
        }

        // GET: Schichten
        public async Task<IActionResult> Index(string searchString)
        {
            var Schichten = from m in _context.Schicht
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Schichten = Schichten.Where(s => s.SchichtName.Contains(searchString));
                
            }

            return View(await Schichten.ToListAsync());
        }

        // GET: Schichten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schicht = await _context.Schicht
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schicht == null)
            {
                return NotFound();
            }

            return View(schicht);
        }

        // GET: Schichten/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Schichten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SchichtName,Tag,Start,Ende,Inhaber,Stunden")] Schicht schicht)
        {
           
                if (ModelState.IsValid)
                {
                schicht.Stunden = (schicht.Ende.Ticks - schicht.Start.Ticks)/ V;
                
                    _context.Add(schicht);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            
            
            return View(schicht);
        }

        // GET: Schichten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schicht = await _context.Schicht.FindAsync(id);
            schicht.Stunden = (schicht.Ende.Ticks - schicht.Start.Ticks)/ V;
            if (schicht == null)
            {
                return NotFound();
            }
            return View(schicht);
        }

        // POST: Schichten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SchichtName,Tag,Start,Ende,Inhaber,Stunden")] Schicht schicht)
        {
            if (id != schicht.Id)
            {
                return NotFound();
            }
            schicht.Stunden = (schicht.Ende.Ticks - schicht.Start.Ticks) / V;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schicht);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchichtExists(schicht.Id))
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
            return View(schicht);
        }

        // GET: Schichten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schicht = await _context.Schicht
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schicht == null)
            {
                return NotFound();
            }

            return View(schicht);
        }

        // POST: Schichten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schicht = await _context.Schicht.FindAsync(id);
            _context.Schicht.Remove(schicht);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchichtExists(int id)
        {
            return _context.Schicht.Any(e => e.Id == id);
        }
    }
}
