using Microsoft.EntityFrameworkCore;
using SallesWebMvc.Data;
using SallesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SallesWebMvc.Services
{
    public class SalesRecordService
    {

        private readonly SallesWebMvcContext _context;

        public SalesRecordService(SallesWebMvcContext context)
        {
            _context = context;
        }

        public SalesRecordService()
        {

        }

        public List<SalesRecord> SimpleSearch(List<string> names)
        {
            try
            {
                List<SalesRecord> sr = new List<SalesRecord>();
                if (names.Count() < 0)
                {
                    return new List<SalesRecord>();
                }
                foreach (string name in names)
                {
                    string n = name.ToUpper();
                    sr = _context.SalesRecord.Include(sl => sl.Seller).Where(sr => sr.Seller.Name.ToUpper().StartsWith(n) || sr.Seller.Name.ToUpper().EndsWith(n)).ToList();
                }
                if (sr == null)
                {
                    sr = new List<SalesRecord>();
                }
                return sr;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("Erro ao tentar fazer a busca" + e.Message);
            }
        }


        public List<SalesRecord> GroupingSearch(string name)
        {
            bool HasValue = string.IsNullOrEmpty(name);

            if (HasValue)
            { 
                return new List<SalesRecord>();
            }
            string[] nameSplit = name.Split(',');
            List<SalesRecord> sr = new List<SalesRecord>();

            foreach (string na in nameSplit)
            {
                string n = na.ToUpper();
                var resultQuery = _context.SalesRecord.Include(sl => sl.Seller).Where(sr => sr.Seller.Name.ToUpper().StartsWith(n) || sr.Seller.Name.ToUpper().EndsWith(n)).FirstOrDefault();
                sr.Add(resultQuery);
            }

            if (sr == null)
            {
                return new List<SalesRecord>();
            }
            return sr;
        }

    }
}
