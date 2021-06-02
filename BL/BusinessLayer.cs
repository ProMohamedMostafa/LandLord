using GenieLandLoardSolution.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenieLandLoardSolution.BL
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly GenieDBlandLoardContext _context;
        public BusinessLayer(GenieDBlandLoardContext context)
        {
            _context = context;
        }

        // DELETE record from table LandLoard
        public async Task<bool> DeleteTbLandLoard(int id)
        {
         
            var landLoard = await _context.TbLandLoards.FindAsync(id);
            if (landLoard != null)
            {
                _context.TbLandLoards.Remove(landLoard);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // get record of company with it's Domain
        public async Task<TbLandLoard> GetTbLandLoard(string domain)
        {
            var company = _context.TbLandLoards.Where(ww=>ww.Domain == domain).FirstOrDefault();
            return company;

        }


        // create new record in LandLoard table
        public async Task<TbLandLoard> PostTbLandLoard(TbLandLoard tbLandLoard)
        {
            _context.TbLandLoards.Add(tbLandLoard);
            await _context.SaveChangesAsync();
            return tbLandLoard;
        }

        public async Task<bool> PutTbLandLoard(int id, TbLandLoard tbLandLoard)
        {
            //_context.Entry(tbLandLoard).State = EntityState.Modified;
            _context.TbLandLoards.Update(tbLandLoard);
            await _context.SaveChangesAsync();

            return true;

        }

        // check if record of this domain Exist or no
        public bool TbLandLoardExists(int id)
        {
                var recordExists = _context.TbLandLoards.Any(e => e.Id == id);
                return recordExists;          
        }
    }
}
