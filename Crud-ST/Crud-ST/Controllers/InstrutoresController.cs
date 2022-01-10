﻿#nullable disable
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
    public class InstrutoresController : Controller
    {
        private readonly Contexto _context;

        public InstrutoresController(Contexto context)
        {
            _context = context;
        }

        // GET: Instrutores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instrutores.ToListAsync());
        }

        // GET: Instrutores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutores = await _context.Instrutores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrutores == null)
            {
                return NotFound();
            }

            return View(instrutores);
        }

        // GET: Instrutores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instrutores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Data,Email,Instagram")] Instrutores instrutores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instrutores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instrutores);
        }

        // GET: Instrutores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutores = await _context.Instrutores.FindAsync(id);
            if (instrutores == null)
            {
                return NotFound();
            }
            return View(instrutores);
        }

        // POST: Instrutores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Data,Email,Instagram")] Instrutores instrutores)
        {
            if (id != instrutores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrutores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrutoresExists(instrutores.Id))
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
            return View(instrutores);
        }

        // GET: Instrutores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutores = await _context.Instrutores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrutores == null)
            {
                return NotFound();
            }

            return View(instrutores);
        }

        // POST: Instrutores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instrutores = await _context.Instrutores.FindAsync(id);
            _context.Instrutores.Remove(instrutores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrutoresExists(int id)
        {
            return _context.Instrutores.Any(e => e.Id == id);
        }
    }
}
