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
    public class Product_ProductTypeController : Controller
    {
        private readonly EShopContext _context;

        public Product_ProductTypeController(EShopContext context)
        {
            _context = context;
        }

        // GET: Product_ProductType
        public async Task<IActionResult> Index()
        {
            var eShopContext = _context.Product_ProductType.Include(p => p.ProductType).Include(p => p.Products);
            return View(await eShopContext.ToListAsync());
        }

        // GET: Product_ProductType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product_ProductType == null)
            {
                return NotFound();
            }

            var product_ProductType = await _context.Product_ProductType
                .Include(p => p.ProductType)
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product_ProductType == null)
            {
                return NotFound();
            }

            return View(product_ProductType);
        }

        // GET: Product_ProductType/Create
        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: Product_ProductType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,ProductTypeId")] Product_ProductType product_ProductType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product_ProductType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "Id", "Id", product_ProductType.ProductTypeId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", product_ProductType.ProductId);
            return View(product_ProductType);
        }

        // GET: Product_ProductType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product_ProductType == null)
            {
                return NotFound();
            }

            var product_ProductType = await _context.Product_ProductType.FindAsync(id);
            if (product_ProductType == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "Id", "Id", product_ProductType.ProductTypeId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", product_ProductType.ProductId);
            return View(product_ProductType);
        }

        // POST: Product_ProductType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,ProductTypeId")] Product_ProductType product_ProductType)
        {
            if (id != product_ProductType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product_ProductType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Product_ProductTypeExists(product_ProductType.Id))
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
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "Id", "Id", product_ProductType.ProductTypeId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", product_ProductType.ProductId);
            return View(product_ProductType);
        }

        // GET: Product_ProductType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product_ProductType == null)
            {
                return NotFound();
            }

            var product_ProductType = await _context.Product_ProductType
                .Include(p => p.ProductType)
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product_ProductType == null)
            {
                return NotFound();
            }

            return View(product_ProductType);
        }

        // POST: Product_ProductType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product_ProductType == null)
            {
                return Problem("Entity set 'EShopContext.Product_ProductType'  is null.");
            }
            var product_ProductType = await _context.Product_ProductType.FindAsync(id);
            if (product_ProductType != null)
            {
                _context.Product_ProductType.Remove(product_ProductType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product_ProductTypeExists(int id)
        {
          return (_context.Product_ProductType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
