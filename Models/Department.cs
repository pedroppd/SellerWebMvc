using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SallesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório !")]
        [StringLength(55, MinimumLength = 4, ErrorMessage = "The size of field name should be between 55 and 4 !")]
        public string Name { get; set; }
        public List<Seller> Sellers { get; set; } = new List<Seller>();
        public int DepartmentId { get; set; }

        public Department()
        {

        }

        public Department(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public void AddSeller(Seller seller)
        {
            this.Sellers.Add(seller);
        }

        public void RemoveSeller(Seller seller)
        {
            this.Sellers.Remove(seller);
        }
        
        
    }
}
