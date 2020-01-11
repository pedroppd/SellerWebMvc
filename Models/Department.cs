using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SallesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Seller> Sellers;

        public Department()
        {

        }
        public Department(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public void addSeller(Seller seller)
        {
            this.Sellers.Add(seller);
        }

        public void removeSeller(Seller seller)
        {
            this.Sellers.Remove(seller);
        }
    }
}
