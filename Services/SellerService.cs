using SallesWebMvc.Data;
using SallesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SallesWebMvc.Services
{
    public class SellerService
    {
        private readonly SallesWebMvcContext _context;

        public SellerService(SallesWebMvcContext context)
        {
            _context = context;
        }
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        public void Update(Seller seller)
        {
            throw new NotImplementedException();
        }
        public void Add(Seller seller)
        {
            if (seller == null)
            {
                throw new Exception("Seller was null");
            }
            _context.Seller.Add(seller);
            _context.SaveChanges();
        }
        public Seller FindById(int? id)
        {
            if (id == null)
            {
                throw new Exception("Id cannot be null");
            }
            return _context.Seller.Include(Seller => Seller.Department).Where(seller => seller.Id == id).FirstOrDefault();
        }
        public void RemoveSeller(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Id cannot be null");
                }
                Seller sellerToRemove = FindById(id);
                _context.Seller.Remove(sellerToRemove);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
