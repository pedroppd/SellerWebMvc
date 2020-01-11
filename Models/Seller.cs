using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SallesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime BithDate { get; set; }

        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        public List<SalesRecord> SalesRecords { get; set; }

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime bithDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BithDate = bithDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addSales(SalesRecord sales)
        {
            this.SalesRecords.Add(sales);
        }

        public void removeSales(SalesRecord sales)
        {
            this.SalesRecords.Remove(sales);
        }

        public void totalSales(DateTime init, DateTime end)
        {
           this.SalesRecords.Where(x => x.Date >= init && x.Date <= end).Sum(x => x.Amount);
        }

        public void countSales(DateTime init, DateTime end)
        {
            this.SalesRecords.Where(x => x.Date >= init && x.Date <= end).Count();
        }

       
    }
}
