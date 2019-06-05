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
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReportsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Orders

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Order.Include(o => o.PaymentType).Include(o => o.User);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> GetOrdersByTopFiveProductTypesIncompleted()
        {
            var products = _context.Product
                .Include(p => p.OrderProducts)
                .ThenInclude(op => op.Order)
                .Where(p => p.OrderProducts.Any(op => op.Order.DateCompleted == null))
                .Include(p => p.ProductType);

            var abandonedProductTypes = products
                .GroupBy(p => p.ProductTypeId,
                         p => p.ProductType,
                        (id, type) => new AbandonedProductTypes
                        {
                            ProductType = type.First(),
                            Count = type.Count()

                        })
                 .OrderByDescending(pt => pt.Count)
                 .Take(5)
                 ;

            //if (orders == null)
            //{
            //    return NotFound();
            //}
            return View(abandonedProductTypes);
        }

        public async Task<IActionResult> Multiples()
        {
            List<ApplicationUser> usersWithMultiples = new List<ApplicationUser>();

            var usersWithIncompleteOrders = _context.ApplicationUsers
                .Include(u => u.Orders)
                .Where(u => u.Orders.Any(o => o.DateCompleted == null))
                .ToList();

            var usersWithMultipleIncompleteOrders = usersWithIncompleteOrders
                .Where(u => u.Orders
                    .Where(o => o.DateCompleted == null)
                    .Count() > 1)
                .ToList()
                .OrderByDescending(u => u.Orders.Where(o => o.DateCompleted == null).Count())
                .ToList();
            return View(usersWithMultipleIncompleteOrders);
        }
        //gets go here

        // GET: Reports/ReportIncompleteOrders
        public async Task<IActionResult> ReportIncompleteOrders()
        {
            var applicationDbContext = _context.Order
                .Include(o => o.User)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .ThenInclude(p => p.ProductType)
                .Where(item => item.DateCompleted == null)
                ;
            return View(await applicationDbContext.ToListAsync());

        }
    }
}
