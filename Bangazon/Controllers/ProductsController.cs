using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bangazon.Data;
using Bangazon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Bangazon.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Products
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            List<Product> productList = await _context.Product
                .Include(p => p.ProductType)
                .Include(p => p.User).ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                productList = productList.Where(p => p.Title.Contains(searchString)
                                      || p.Description.Contains(searchString)).ToList();
            }

            var applicationDbContext = productList
                .OrderByDescending(p => p.DateCreated)
                //Shows specified amount
                .Take(20);

            return View(applicationDbContext);
        }

        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            var products = _context.Product
                .Include(p => p.ProductType)
                .Include(p => p.User)
                .Where(p => p.ProductTypeId == id);
            if (products == null)
            {
                return NotFound();
            }
            return View(await products.ToListAsync());
        }

        public async Task<IActionResult> MyProducts()
        {
            var loggedInUser = await GetCurrentUserAsync();
            var products = _context.Product
                .Include(p => p.ProductType)
                .Where(p => p.UserId == loggedInUser.Id);
            if (products == null)
            {
                return NotFound();
            }
            return View(await products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductType)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> PlaceOrder(int? id)
        {
            //new method for when the user clicks on the 'Add to Order' button on the product details view


            if (id == null)
            {
                return NotFound();
            }

            // variable capturing the current user to be used when a newOrder instance is created on line 127

            var loggedInUser = await GetCurrentUserAsync();


            var isOrder = _context.Order.Where(o => o.UserId == loggedInUser.Id && o.PaymentTypeId == null);
             
            // both newOrderId and WorkingOrder initially set to null to capture variable 
            int? newOrderId = null;

            Order WorkingOrder = null;


            //ternary statement to see if order is empty, if so create a new instance of an order 
            if (isOrder == null)
            {
               
            Order newOrder = new Order
            {
                UserId = loggedInUser.Id.ToString()
            };

            _context.Order.Add(newOrder);
            await _context.SaveChangesAsync();

            newOrderId = newOrder.OrderId;
                WorkingOrder = newOrder;
            } 
            else
            {
                foreach(Order item in isOrder) {

                    newOrderId = item.OrderId;
                    WorkingOrder = item;
                }
               
            }
            
            var product = await _context.Product
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }


            var productQty = product.Quantity;


            // new instance of a join table with productId and newOrderId

            OrderProduct ProductOrder = new OrderProduct
            {
                OrderId = (int)newOrderId,
                ProductId = product.ProductId
            };

            //_context goes into database and adds the new ProductOrder to the OrderProduct table
            _context.OrderProduct.Add(ProductOrder);


            //saves changes
            await _context.SaveChangesAsync();


            //updates quantity of product minus one
            product.Quantity = product.Quantity -1;



            //goes into database and updates with new product
            _context.Update(product);
            await _context.SaveChangesAsync();


            //return View("../Orders/Details", WorkingOrder);
            return RedirectToAction("Details", "Products", new { id });
        }
        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,DateCreated,Description,Title,Price,Quantity,UserId,City,ImagePath,ProductTypeId")] Product product)
        {
            ModelState.Remove("User");
            ModelState.Remove("UserId");
            var loggedInUser = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                product.UserId = loggedInUser.Id;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            

            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label", product.ProductTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", product.UserId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label", product.ProductTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", product.UserId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,DateCreated,Description,Title,Price,Quantity,UserId,City,ImagePath,ProductTypeId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label", product.ProductTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", product.UserId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductType)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loggedInUser = await GetCurrentUserAsync();
            var product = await _context.Product.FindAsync(id);

            if (product.UserId == loggedInUser.Id)
            {
                Product freeProduct = null;
                foreach (var item in _context.OrderProduct)
                {
                    if (product.ProductId != item.ProductId)
                    {
                        freeProduct = product;
                    }
                }

                if (freeProduct != null)
                {
                    _context.Product.Remove(freeProduct);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(MyProducts));
                }
                else
                {
                    //error product in order
                    return View("UserError", product);
                }
            }
            else
            {
                //error
                return View("UserError", product);
            }

        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
