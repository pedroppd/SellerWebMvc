using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SallesWebMvc.Data;
using SallesWebMvc.Models;
using SallesWebMvc.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SallesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService service;

        public SellersController(SellerService SellerService)
        {
            service = SellerService;
        }


        public IActionResult Index()
        {
            List<Seller> sellers = service.FindAll();
            return View(sellers);
        }

        public async Task<IActionResult> FindSellerById(int? id)
        {
            Seller seller = service.FindById(id);
            return View(seller);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
           
            service.Add(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }


        public IActionResult Edit(int? id, Seller seller)
        {
            service.Update(seller);
            return View(seller);
        }

    }


}
