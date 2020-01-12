﻿using SallesWebMvc.Data;
using SallesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
        }

        public Seller FindById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
