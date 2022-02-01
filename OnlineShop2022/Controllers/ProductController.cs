using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop2022.Data;
using OnlineShop2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using OnlineShop2022.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShop2022.Controllers
{
    [Authorize(Roles = "Manager, Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;
        private Images _images;

        public ProductController(AppDbContext db, IWebHostEnvironment webHostEnvironment, Images images)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = db;
            _images = images;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _db.Products.ToListAsync();
            return View(products);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var file = Request.Form.Files[0];

                    if (file != null)
                    {
                        product.ImagePath = _images.Upload(file, $"/images/products/");
                        await _db.Products.AddAsync(product);
                        await _db.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception)
                {
                    return View(product);
                }
                 
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ProductModel product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    try
                    {
                        var file = Request.Form.Files[0];

                        if (file != null)
                        {
                            _images.Delete(product.ImagePath);
                            product.ImagePath = _images.Upload(file, $"/images/products/");
                        }
                    }
                    catch (Exception)
                    { }

                    _db.Products.Update(product);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return NotFound();
                }
            }
            return View(product);
        }

        //GET
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel currentProduct = await _db.Products.FindAsync(id);

            if (currentProduct == null)
            {
                return NotFound();
            }

            return View(currentProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, ProductModel model)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel productToDelete = await _db.Products.FindAsync(id);

            if (productToDelete == null)
            {
                return NotFound();
            }

             _db.Products.Remove(productToDelete);
            await _db.SaveChangesAsync();

           _images.Delete(productToDelete.ImagePath);

            return RedirectToAction(nameof(Index));

        }



        //GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel currentProduct = await _db.Products.FindAsync(id);

            if (currentProduct == null)
            {
                return NotFound();
            }

            return View(currentProduct);
        }



    }
}
