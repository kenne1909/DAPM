﻿using DAPM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAPM.Controllers
{
    public class DOTLUController : Controller
    {
        private DbLuLutHoaVangContext _context;
        public DOTLUController(DbLuLutHoaVangContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var dotLus = await _context.TbDotLus.ToListAsync();
            return View(dotLus);
        }
        public async Task<IActionResult> Edit(long id)
        {
            var dotLu = await _context.TbDotLus.FindAsync(id);
            if (dotLu == null)
            {
                return NotFound();
            }
            return View(dotLu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Models.TbDotLu dotLu)
        {
            if (id != dotLu.IdDotLu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(dotLu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dotLu);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var dotLu = await _context.TbDotLus.FindAsync(id);
            if (dotLu == null)
            {
                return NotFound();
            }

            _context.TbDotLus.Remove(dotLu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
