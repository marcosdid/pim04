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

    public class MetodoPagamentoController : Controller
    {
        private readonly Data.ApplicationDbContext _context;

        public MetodoPagamentoController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MetodoPagamento
        public async Task<IActionResult> Index()
        {
            return View(await _context.MetodoPagamentos.ToListAsync());
        }

        // GET: MetodoPagamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPagamento = await _context.MetodoPagamentos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (metodoPagamento == null)
            {
                return NotFound();
            }

            return View(metodoPagamento);
        }

        // GET: MetodoPagamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MetodoPagamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome")] MetodoPagamento metodoPagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metodoPagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metodoPagamento);
        }

        // GET: MetodoPagamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPagamento = await _context.MetodoPagamentos.FindAsync(id);
            if (metodoPagamento == null)
            {
                return NotFound();
            }
            return View(metodoPagamento);
        }

        // POST: MetodoPagamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome")] MetodoPagamento metodoPagamento)
        {
            if (id != metodoPagamento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metodoPagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetodoPagamentoExists(metodoPagamento.ID))
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
            return View(metodoPagamento);
        }

        // GET: MetodoPagamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPagamento = await _context.MetodoPagamentos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (metodoPagamento == null)
            {
                return NotFound();
            }

            return View(metodoPagamento);
        }

        // POST: MetodoPagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metodoPagamento = await _context.MetodoPagamentos.FindAsync(id);
            _context.MetodoPagamentos.Remove(metodoPagamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetodoPagamentoExists(int id)
        {
            return _context.MetodoPagamentos.Any(e => e.ID == id);
        }
    }
}
