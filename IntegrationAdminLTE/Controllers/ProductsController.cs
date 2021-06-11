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
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return RedirectToAction("Create");
        }
    }
}
