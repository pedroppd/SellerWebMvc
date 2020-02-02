using SallesWebMvc.Data;
using SallesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SallesWebMvc.Services.Exception;
using System.Threading.Tasks;

namespace SallesWebMvc.Services
{
    public class SellerService
    {
        private readonly SallesWebMvcContext _context;

        public SellerService(SallesWebMvcContext context)
        {
            _context = context;
        }
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }
        public async Task UpdateAsync(Seller seller)
        {
            try
            {
                if (!_context.Seller.Any(x => x.Id == seller.Id))
                {
                    throw new NotFoundException("Id not found");
                }
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
        public async Task Add(Seller seller)
        {
            if (seller == null)
            {
                throw new NullReferenceException("Seller was null");
            }
            _context.Seller.Add(seller);
            await _context.SaveChangesAsync();
        }
        public async Task<Seller> FindByIdAsync(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("Id cannot be null");
            }
            return await _context.Seller.Include(Seller => Seller.Department).Where(seller => seller.Id == id).FirstOrDefaultAsync();
        }
        public async Task RemoveSellerAsync(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new NullReferenceException("Id cannot be null");
                }
                Task<Seller> sellerToRemove = FindByIdAsync(id);
                _context.Seller.Remove(sellerToRemove.Result);
                await _context.SaveChangesAsync();
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }
    }
}
