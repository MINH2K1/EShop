using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EShop.Data;
using EShop.Models;

namespace EShop.Controllers
{
    public class InvoiceDetailsController : Controller
    {
        private readonly EShopContext _context;

        public InvoiceDetailsController(EShopContext context)
        {
            _context = context;
        }

        // GET: InvoiceDetails
        public async Task<IActionResult> Index()
        {
              return _context.InvoiceDetail != null ? 
                          View(await _context.InvoiceDetail.ToListAsync()) :
                          Problem("Entity set 'EShopContext.InvoiceDetail'  is null.");
        }

        // GET: InvoiceDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InvoiceDetail == null)
            {
                return NotFound();
            }

            var invoiceDetail = await _context.InvoiceDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvoiceDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Quantity,UserId")] InvoiceDetail invoiceDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InvoiceDetail == null)
            {
                return NotFound();
            }

            var invoiceDetail = await _context.InvoiceDetail.FindAsync(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }
            return View(invoiceDetail);
        }

        // POST: InvoiceDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Quantity,UserId")] InvoiceDetail invoiceDetail)
        {
            if (id != invoiceDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceDetailExists(invoiceDetail.Id))
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
            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InvoiceDetail == null)
            {
                return NotFound();
            }

            var invoiceDetail = await _context.InvoiceDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return View(invoiceDetail);
        }

        // POST: InvoiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InvoiceDetail == null)
            {
                return Problem("Entity set 'EShopContext.InvoiceDetail'  is null.");
            }
            var invoiceDetail = await _context.InvoiceDetail.FindAsync(id);
            if (invoiceDetail != null)
            {
                _context.InvoiceDetail.Remove(invoiceDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceDetailExists(int id)
        {
          return (_context.InvoiceDetail?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
