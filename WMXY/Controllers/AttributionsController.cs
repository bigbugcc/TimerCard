using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimerCard.Models;

namespace TimerCard.Controllers
{
    public class AttributionsController : Controller
    {
        private readonly ToDoContext _context;

        public AttributionsController(ToDoContext context)
        {
            _context = context;
        }

        // GET: Attributions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Attribution.ToListAsync());
        }

        public async Task<List<Attribution>> GetAttrs()
        {
            List<Attribution> attributions = new List<Attribution>();
            var data = await _context.Attribution.ToListAsync();
            foreach (var item in data) {
                attributions.Add(new Attribution {Id = item.Id,classDescription = item.classDescription });
            }  

            return attributions;
        }

        // GET: Attributions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribution = await _context.Attribution
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attribution == null)
            {
                return NotFound();
            }

            return View(attribution);
        }

        // GET: Attributions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attributions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,classDescription,collegeId,majorId,classId,customerId")] Attribution attribution)
        {
            if (ModelState.IsValid)
            {
                attribution.Id = Guid.NewGuid().ToString();
                _context.Add(attribution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attribution);
        }

        // GET: Attributions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribution = await _context.Attribution.FindAsync(id);
            if (attribution == null)
            {
                return NotFound();
            }
            return View(attribution);
        }

        // POST: Attributions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,classDescription,collegeId,majorId,classId,customerId")] Attribution attribution)
        {
            if (id != attribution.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attribution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttributionExists(attribution.Id))
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
            return View(attribution);
        }

        // GET: Attributions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribution = await _context.Attribution
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attribution == null)
            {
                return NotFound();
            }

            return View(attribution);
        }

        // POST: Attributions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var attribution = await _context.Attribution.FindAsync(id);
            _context.Attribution.Remove(attribution);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttributionExists(string id)
        {
            return _context.Attribution.Any(e => e.Id == id);
        }
    }
}
