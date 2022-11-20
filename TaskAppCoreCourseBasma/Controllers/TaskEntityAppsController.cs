using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApp.Models;

namespace TaskAppCoreCourseBasma.Controllers
{
    public class TaskEntityAppsController : Controller
    {
        private readonly TaskAppCoreCourseContext _context;

        public TaskEntityAppsController(TaskAppCoreCourseContext context)
        {
            _context = context;
        }

        // GET: TaskEntityApps
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaskEntityApp.ToListAsync());
        }

        // GET: TaskEntityApps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEntityApp = await _context.TaskEntityApp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskEntityApp == null)
            {
                return NotFound();
            }

            return View(taskEntityApp);
        }

        // GET: TaskEntityApps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskEntityApps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Priority,Dateadded")] TaskEntityApp taskEntityApp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskEntityApp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskEntityApp);
        }

        // GET: TaskEntityApps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEntityApp = await _context.TaskEntityApp.FindAsync(id);
            if (taskEntityApp == null)
            {
                return NotFound();
            }
            return View(taskEntityApp);
        }

        // POST: TaskEntityApps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Priority,Dateadded")] TaskEntityApp taskEntityApp)
        {
            if (id != taskEntityApp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskEntityApp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskEntityAppExists(taskEntityApp.Id))
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
            return View(taskEntityApp);
        }

        // GET: TaskEntityApps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEntityApp = await _context.TaskEntityApp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskEntityApp == null)
            {
                return NotFound();
            }

            return View(taskEntityApp);
        }

        // POST: TaskEntityApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskEntityApp = await _context.TaskEntityApp.FindAsync(id);
            _context.TaskEntityApp.Remove(taskEntityApp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskEntityAppExists(int id)
        {
            return _context.TaskEntityApp.Any(e => e.Id == id);
        }
    }
}
