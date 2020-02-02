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
        public async Task<IActionResult> Index()
        {
            var sellers = await service.FindAllAsync();
            return View(sellers);
        }
        public async Task<IActionResult> FindSellerById(int? id)
        {
            var seller = await service.FindByIdAsync(id);
            return View(seller);
        }
        public async Task<IActionResult> Create()
        {
            var departments = await DepartmentService.FindAllAsync();
            SellerFormViewModel ViewModel = new SellerFormViewModel { Departments = departments };
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var Department = await DepartmentService.FindAllAsync();
                var ViewModel = new SellerFormViewModel { Seller = seller, Departments = Department };
                return View(ViewModel);
            }
            await service.Add(seller);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var seller = await service.FindByIdAsync(id.Value);

            List<Department> departments = await DepartmentService.FindAllAsync();
            SellerFormViewModel ViewModel = new SellerFormViewModel { Departments = departments, Seller = seller };
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }
            try
            {
                await service.UpdateAsync(seller);
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
        public async Task<IActionResult> Delete(int? id)
        {
            Seller seller = await service.FindByIdAsync(id.Value);
            return View(seller);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try { 
                await service.RemoveSellerAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            Seller seller = await service.FindByIdAsync(id);
            return View(seller);
        }

        public IActionResult Error(string message)
        {
            var ViewModel = new ErrorViewModel { message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(ViewModel);
        }
       
    }
}



