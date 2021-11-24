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

    public class ReservaController : Controller
    {
        private readonly Data.ApplicationDbContext _context;

        public ReservaController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reserva
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservas.Include(r => r.Hospede).Include(r => r.MetodoPagamento).Include(r => r.Quarto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Hospede)
                .Include(r => r.MetodoPagamento)
                .Include(r => r.Quarto)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            ViewData["HospedeId"] = new SelectList(_context.Hospedes, "ID", "Nome");
            ViewData["QuartoId"] = new SelectList(_context.Quartos, "ID", "Nome");
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,HospedeId,DataEntrada,DataSaida,QuartoId,NumeroQuarto")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HospedeId"] = new SelectList(_context.Hospedes, "ID", "Nome", reserva.HospedeId);
            ViewData["QuartoId"] = new SelectList(_context.Quartos, "ID", "Nome", reserva.QuartoId);
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["HospedeId"] = new SelectList(_context.Hospedes, "ID", "Celular", reserva.HospedeId);
            ViewData["MetodoPagamentoId"] = new SelectList(_context.MetodoPagamentos, "ID", "Nome", reserva.MetodoPagamentoId);
            ViewData["QuartoId"] = new SelectList(_context.Quartos, "ID", "Nome", reserva.QuartoId);
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HospedeId,DataEntrada,DataSaida,QuartoId,NumeroQuarto,MetodoPagamentoId")] Reserva reserva)
        {
            if (id != reserva.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.ID))
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
            ViewData["HospedeId"] = new SelectList(_context.Hospedes, "ID", "Celular", reserva.HospedeId);
            ViewData["MetodoPagamentoId"] = new SelectList(_context.MetodoPagamentos, "ID", "Nome", reserva.MetodoPagamentoId);
            ViewData["QuartoId"] = new SelectList(_context.Quartos, "ID", "Nome", reserva.QuartoId);
            return View(reserva);
        }

        // GET: Reserva/CheckUp/5
        public async Task<IActionResult> CheckUp(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["HospedeId"] = new SelectList(_context.Hospedes, "ID", "Celular", reserva.HospedeId);
            ViewData["MetodoPagamentoId"] = new SelectList(_context.MetodoPagamentos, "ID", "Nome", reserva.MetodoPagamentoId);
            ViewData["QuartoId"] = new SelectList(_context.Quartos, "ID", "Nome", reserva.QuartoId);
            return View(reserva);
        }

        // POST: Reserva/CheckUp/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckUp(int id, [Bind("ID,HospedeId,DataEntrada,DataSaida,QuartoId,NumeroQuarto,MetodoPagamentoId")] Reserva reserva)
        {
            if (id != reserva.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.ID))
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
            ViewData["HospedeId"] = new SelectList(_context.Hospedes, "ID", "Celular", reserva.HospedeId);
            ViewData["MetodoPagamentoId"] = new SelectList(_context.MetodoPagamentos, "ID", "Nome", reserva.MetodoPagamentoId);
            ViewData["QuartoId"] = new SelectList(_context.Quartos, "ID", "Nome", reserva.QuartoId);
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Hospede)
                .Include(r => r.MetodoPagamento)
                .Include(r => r.Quarto)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.ID == id);
        }
    }
}
