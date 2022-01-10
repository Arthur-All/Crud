#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crud_Ins.Models;
using Crud_ST.Models;

namespace Crud_ST.Controllers
{
    public class LivesController : Controller
    {
        private readonly Contexto _context;

        public LivesController(Contexto context)
        {
            _context = context;
        }

        // GET: Lives
        public async Task<IActionResult> Index()
        {
            return View(await _context.Live.ToListAsync());
        }

        // GET: Lives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _context.Live
                .FirstOrDefaultAsync(m => m.Id == id);
            if (live == null)
            {
                return NotFound();
            }

            return View(live);
        }

        // GET: Lives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Instrutor,Data,Duracao,Valor")] Live live)
        {
            if (ModelState.IsValid)
            {
                _context.Add(live);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(live);
        }

        // GET: Lives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _context.Live.FindAsync(id);
            if (live == null)
            {
                return NotFound();
            }
            return View(live);
        }

        // POST: Lives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Instrutor,Data,Duracao,Valor")] Live live)
        {
            if (id != live.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(live);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LiveExists(live.Id))
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
            return View(live);
        }

        // GET: Lives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _context.Live
                .FirstOrDefaultAsync(m => m.Id == id);
            if (live == null)
            {
                return NotFound();
            }

            return View(live);
        }

        // POST: Lives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var live = await _context.Live.FindAsync(id);
            _context.Live.Remove(live);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LiveExists(int id)
        {
            return _context.Live.Any(e => e.Id == id);
        }
    }
}
