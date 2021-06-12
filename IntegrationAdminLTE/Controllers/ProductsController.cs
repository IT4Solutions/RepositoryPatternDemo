using IntegrationAdminLTE.Data;
using IntegrationAdminLTE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdminLTE.Controllers
{
    public class ProductsController : Controller
    {
        public StoreContext _context { get; }
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ProductList()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if(product.Id > 0)
            {
                _context.Products.Update(product);
            }
            else
            {
                _context.Products.Add(product);
            }
            

            await _context.SaveChangesAsync();

            return RedirectToAction("ProductList");
        }

        public async Task<IActionResult> Edit(int id=0)
        {
            if (id <= 0)
                return BadRequest();

            var productInDB = await _context.Products.FindAsync(id);

            if (productInDB == null)
                return NotFound();

            return View("Create", productInDB);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
                return BadRequest();

            var productInDB = await _context.Products.FindAsync(id);

            if (productInDB == null)
                return NotFound();

            return View(productInDB);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var productInDB = await _context.Products.FindAsync(id);

            if (productInDB == null)
                return NotFound();

             _context.Products.Remove(productInDB);

            await _context.SaveChangesAsync();

            return RedirectToAction("ProductList");
        }
    }
}
