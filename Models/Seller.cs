using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SallesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório !")]
        [StringLength(55, MinimumLength = 4, ErrorMessage = "The size of field name should be between 55 and 4 !")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O e-mail é obrigatório !")]
        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "O campo Birth date é obrigatório !")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "O campo base salary é obrigatório !")]
        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public int DepartmentId { get; set; }
        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
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
