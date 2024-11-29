using Microsoft.AspNetCore.Mvc;
using SHNgms.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SHNgms.Controllers
{
    public class GrantController : Controller
    {
        private readonly SHNgmsContext _context;

        public GrantController(SHNgmsContext context)
        {
            _context = context;
        }

        // GET: Grant
        public IActionResult Index()
        {
            var grants = _context.Grants.ToList();
            return View(grants);
        }

        // GET: Grant/Details/5
        public IActionResult Details(int id)
        {
            var grant = _context.Grants
                .FirstOrDefault(g => g.Id == id);

            if (grant == null)
            {
                return NotFound();
            }

            return View(grant);
        }

        // GET: Grant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,TotalFundsAllocated,FundsSpent,Status,AwardedDate,CompletionDate")] Grant grant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grant);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(grant);
        }

        // GET: Grant/Edit/5
        public IActionResult Edit(int id)
        {
            var grant = _context.Grants.Find(id);
            if (grant == null)
            {
                return NotFound();
            }
            return View(grant);
        }

        // POST: Grant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,TotalFundsAllocated,FundsSpent,Status,AwardedDate,CompletionDate")] Grant grant)
        {
            if (id != grant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grant);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Grants.Any(e => e.Id == grant.Id))
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
            return View(grant);
        }

        // GET: Grant/Delete/5
        public IActionResult Delete(int id)
        {
            var grant = _context.Grants
                .FirstOrDefault(g => g.Id == id);

            if (grant == null)
            {
                return NotFound();
            }

            return View(grant);
        }

        // POST: Grant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var grant = _context.Grants.Find(id);
            _context.Grants.Remove(grant);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
