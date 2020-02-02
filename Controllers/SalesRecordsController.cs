using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SallesWebMvc.Data;
using SallesWebMvc.Models;
using SallesWebMvc.Services;

namespace SallesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
     
     
        SalesRecordService service = new SalesRecordService();

        public SalesRecordsController(SalesRecordService services)
        {
            service = services;
        }

        // GET: SalesRecords
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SimpleSearch(string name)
        {
             
            List<SalesRecord> sellers = new List<SalesRecord>();
            List<string> names = new List<string>();
            names.Add(name);
            if (names.Count < 1)
            {
                return RedirectToAction(nameof(Index), new { message = "Nenhum seller encontrado" });
            }
            sellers = service.SimpleSearch(names);

            if (sellers == null)
            {
                return RedirectToAction(nameof(Index), new { message = "Nenhum seller encontrado" });
            }

            return View(sellers);
        }

        [HttpPost]
        public IActionResult GroupingSearch(string name)
        {
            bool value = string.IsNullOrEmpty(name);

            if (value)
            {
                return null;
            }

            List<SalesRecord> salesRecord = service.GroupingSearch(name);

            return RedirectToAction(nameof(SimpleSearch), salesRecord);
        }

       

    }
}
