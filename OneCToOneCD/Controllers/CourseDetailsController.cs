using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneCToOneCD.Models;

namespace OneCToOneCD.Controllers
{
    public class CourseDetailsController : Controller
    {
        public AppDbContext _context;

        public CourseDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CourseDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.CoursesDetails.ToListAsync());
        }

        // GET: CourseDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDetails = await _context.CoursesDetails
                .FirstOrDefaultAsync(m => m.CourseCode == id);
            if (courseDetails == null)
            {
                return NotFound();
            }

            return View(courseDetails);
        }

        // GET: CourseDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseCode,CourseName,Price,DurationInWeeks")] CourseDetails courseDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseDetails);
        }

        // GET: CourseDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDetails = await _context.CoursesDetails.FindAsync(id);
            if (courseDetails == null)
            {
                return NotFound();
            }
            return View(courseDetails);
        }

        // POST: CourseDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CourseCode,CourseName,Price,DurationInWeeks")] CourseDetails courseDetails)
        {
            if (id != courseDetails.CourseCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseDetailsExists(courseDetails.CourseCode))
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
            return View(courseDetails);
        }

        // GET: CourseDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDetails = await _context.CoursesDetails
                .FirstOrDefaultAsync(m => m.CourseCode == id);
            if (courseDetails == null)
            {
                return NotFound();
            }

            return View(courseDetails);
        }

        // POST: CourseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var courseDetails = await _context.CoursesDetails.FindAsync(id);
            if (courseDetails != null)
            {
                _context.CoursesDetails.Remove(courseDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseDetailsExists(string id)
        {
            return _context.CoursesDetails.Any(e => e.CourseCode == id);
        }
    }
}
