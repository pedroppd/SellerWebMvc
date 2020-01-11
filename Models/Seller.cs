using System;
using System.Collections.Generic;
using System.Linq;

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

        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

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

        public void AddSales(SalesRecord sales)
        {
            this.SalesRecords.Add(sales);
        }

        public void RemoveSales(SalesRecord sales)
        {
            this.SalesRecords.Remove(sales);
        }
        public double TotalSales(DateTime init, DateTime end)
        {
          return this.SalesRecords.Where(x => x.Date >= init && x.Date <= end).Sum(x => x.Amount);
        }

        public int CountSales(DateTime init, DateTime end)
        {
           return this.SalesRecords.Where(x => x.Date >= init && x.Date <= end).Count();
        }

    }
}
