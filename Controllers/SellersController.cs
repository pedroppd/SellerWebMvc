using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SallesWebMvc.Data;
using SallesWebMvc.Models;
using SallesWebMvc.Models.ViewModels;
using SallesWebMvc.Services;
using SallesWebMvc.Services.Exception;
using System.Collections.Generic;
using System.Diagnostics;
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
        public IActionResult Edit(int? id)
        {
            Seller seller = service.FindById(id);

            List<Department> departments = DepartmentService.FindAll();
            SellerFormViewModel ViewModel = new SellerFormViewModel { Departments = departments, Seller = seller };
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }
            try
            {
                service.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction(nameof(Error), new { message = "id was null"});
            }
            catch (DbConcurrencyException ex)
            {
                return RedirectToAction(nameof(Error), new { message = "id not found" });
            }
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

        public IActionResult Error(string message)
        {
            var ViewModel = new ErrorViewModel { message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(ViewModel);
        }

    }
}



