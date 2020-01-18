using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SallesWebMvc.Data;
using SallesWebMvc.Models;
using SallesWebMvc.Models.ViewModels;
using SallesWebMvc.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SallesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService service;
        private readonly DepartmentService DepartmentService;
        public SellersController(SellerService SellerService, DepartmentService departmentService)
        {
            service = SellerService;
            DepartmentService = departmentService;
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
            List<Department> departments = DepartmentService.FindAll();
            SellerFormViewModel ViewModel = new SellerFormViewModel { Departments = departments };
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public IActionResult Delete(int? id)
        {
            Seller seller = service.FindById(id.Value);
            return View(seller);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            service.RemoveSeller(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            Seller seller = service.FindById(id);
            return View(seller);
        }
    }


}
