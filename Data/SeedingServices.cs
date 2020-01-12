using SallesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SallesWebMvc.Data
{
    public class SeedingServices
    {
        private readonly SallesWebMvcContext _context;

        public SeedingServices(SallesWebMvcContext Context)
        {
            _context = Context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; // if happines some value in entitys, don't will create another database
            }
            
            //Departamentos.
            Department d1 = new Department(1, "Fashion");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Computers");
            Department d4 = new Department(4, "Clocks");
            Department d5 = new Department(5, "Boots");

            //Vendedores
            Seller s1 = new Seller(1, "João marcos", "joão@hotmail.com", new DateTime(1997, 5, 2), 2000.00, d2);
            Seller s2 = new Seller(2, "Gabriela oliveira", "joão@hotmail.com", new DateTime(1999, 8, 12), 1500.00, d1);
            Seller s3 = new Seller(3, "Hamilton júnior", "hamilton@hotmail.com", new DateTime(1995, 7, 15), 1500.00, d5);
            Seller s4 = new Seller(4, "Frederico da silta", "fred@hotmail.com", new DateTime(1998, 3, 11), 5000.00, d3);
            Seller s5 = new Seller(5, "Edmundo oliveira", "edmundo@hotmail.com", new DateTime(1994, 6, 12), 2500.00, d4);

            //Salles Record
            SalesRecord sr1 = new SalesRecord(1, new DateTime(2019, 12, 12),5000.00,  Models.Enums.SalesStatus.PEDING, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2018, 10, 3), 10.000, Models.Enums.SalesStatus.CANCELED, s2);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2017, 06, 3), 8.000, Models.Enums.SalesStatus.BILLED, s3);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2015, 05, 3), 200.000, Models.Enums.SalesStatus.PEDING, s4);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2016, 01, 20), 75.000, Models.Enums.SalesStatus.BILLED, s5);

            _context.Department.AddRange(d1, d2, d3, d4, d5); //Saving departments
            _context.Seller.AddRange(s1, s2, s3, s4, s5); //Saving sellers
            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5); //Saving Sales Record

            _context.SaveChanges();

        }

    }
}
