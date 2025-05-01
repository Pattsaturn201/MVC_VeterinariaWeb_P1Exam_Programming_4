using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EdwinSaa_MVC_Veterinaria_ExamenP1_P4.Models;

namespace EdwinSaa_MVC_Veterinaria_ExamenP1_P4.Controllers
{
    public class VeterinaryAppointmentsController : Controller
    {
        private readonly SQLServerContextSJCP _context;

        public VeterinaryAppointmentsController(SQLServerContextSJCP context)
        {
            _context = context;
        }

        // GET: VeterinaryAppointments
        public async Task<IActionResult> Index()
        {
            var sQLServerContextSJCP = _context.VeterinaryAppointment.Include(v => v.Owner).Include(v => v.Pet);
            return View(await sQLServerContextSJCP.ToListAsync());
        }

        // GET: VeterinaryAppointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinaryAppointment = await _context.VeterinaryAppointment
                .Include(v => v.Owner)
                .Include(v => v.Pet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veterinaryAppointment == null)
            {
                return NotFound();
            }

            return View(veterinaryAppointment);
        }

        // GET: VeterinaryAppointments/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Owner, "Id", "Id");
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Id");
            return View();
        }

        // POST: VeterinaryAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AppointentDate,Reason,Status,PetId,OwnerId,RequiresMedication")] VeterinaryAppointment veterinaryAppointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veterinaryAppointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Owner, "Id", "Id", veterinaryAppointment.OwnerId);
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Id", veterinaryAppointment.PetId);
            return View(veterinaryAppointment);
        }

        // GET: VeterinaryAppointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinaryAppointment = await _context.VeterinaryAppointment.FindAsync(id);
            if (veterinaryAppointment == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Owner, "Id", "Id", veterinaryAppointment.OwnerId);
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Id", veterinaryAppointment.PetId);
            return View(veterinaryAppointment);
        }

        // POST: VeterinaryAppointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AppointentDate,Reason,Status,PetId,OwnerId,RequiresMedication")] VeterinaryAppointment veterinaryAppointment)
        {
            if (id != veterinaryAppointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veterinaryAppointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeterinaryAppointmentExists(veterinaryAppointment.Id))
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
            ViewData["OwnerId"] = new SelectList(_context.Owner, "Id", "Id", veterinaryAppointment.OwnerId);
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Id", veterinaryAppointment.PetId);
            return View(veterinaryAppointment);
        }

        // GET: VeterinaryAppointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinaryAppointment = await _context.VeterinaryAppointment
                .Include(v => v.Owner)
                .Include(v => v.Pet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veterinaryAppointment == null)
            {
                return NotFound();
            }

            return View(veterinaryAppointment);
        }

        // POST: VeterinaryAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veterinaryAppointment = await _context.VeterinaryAppointment.FindAsync(id);
            if (veterinaryAppointment != null)
            {
                _context.VeterinaryAppointment.Remove(veterinaryAppointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeterinaryAppointmentExists(int id)
        {
            return _context.VeterinaryAppointment.Any(e => e.Id == id);
        }
    }
}
