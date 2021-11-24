using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pim04.Data;
using pim04.Models;
using Microsoft.AspNetCore.Authorization;


namespace pim04.Controllers
{
    [Authorize]

    public class QuartoController : Controller
    {
        private readonly Data.ApplicationDbContext _context;
        
        public QuartoController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Quarto
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quartos.ToListAsync());
        }

        // GET: Quarto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarto = await _context.Quartos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (quarto == null)
            {
                return NotFound();
            }

            return View(quarto);
        }

        // GET: Quarto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quarto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Preco")] Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quarto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quarto);
        }

        // GET: Quarto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarto = await _context.Quartos.FindAsync(id);
            if (quarto == null)
            {
                return NotFound();
            }
            return View(quarto);
        }

        // POST: Quarto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Preco")] Quarto quarto)
        {
            if (id != quarto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quarto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuartoExists(quarto.ID))
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
            return View(quarto);
        }

        // GET: Quarto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarto = await _context.Quartos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (quarto == null)
            {
                return NotFound();
            }

            return View(quarto);
        }

        // POST: Quarto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quarto = await _context.Quartos.FindAsync(id);
            _context.Quartos.Remove(quarto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuartoExists(int id)
        {
            return _context.Quartos.Any(e => e.ID == id);
        }
    }
}
