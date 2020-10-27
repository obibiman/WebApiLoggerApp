using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiRestLogging.Database;
using WebApiRestLogging.Models;

namespace WebApiRestLogging.Services
{
    /// <summary>
    /// GroceryRepository
    /// </summary>
    public class GroceryRepository : IGroceryRepository
    {
        private readonly GroceryContext _ctxt;

        /// <summary>
        /// GroceryRepository Constructor
        /// </summary>
        /// <param name="ctxt"></param>
        public GroceryRepository(GroceryContext ctxt)
        {
            _ctxt = ctxt;
        }

        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Grocery</returns>
        public async Task<Grocery> GetByIdAsync(int Id)
        {
            var grocerySku = await _ctxt.Groceries.FirstOrDefaultAsync(y => y.Id == Id);
            return grocerySku;
        }

        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="grocery"></param>
        /// <returns>Grocery</returns>
        public async Task<Grocery> CreateAsync(Grocery grocery)
        {
            if (grocery == null)
            {
                throw new ArgumentNullException(nameof(grocery));
            }
            _ctxt.Set<Grocery>().Add(grocery);
            await _ctxt.SaveChangesAsync();
            return grocery;
        }

        /// <summary>
        /// DeleteAysnc
        /// </summary>
        /// <param name="grocery"></param>
        /// <returns>Void</returns>
        public async Task DeleteAsync(Grocery grocery)
        {
            Task<Grocery> grocerySku = _ctxt.Groceries.FirstOrDefaultAsync(y => y.Id == grocery.Id);

            if (grocerySku != null)
            {
                var theId = grocerySku.Id;
                _ctxt.Set<Grocery>().Remove(grocery);
            }
            await _ctxt.SaveChangesAsync();
        }

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns>List of Grocery</returns>
        public async Task<IEnumerable<Grocery>> GetAllAsync()
        {
            List<Grocery> grocerySku = await _ctxt.Groceries.ToListAsync();
            return grocerySku;
        }

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="grocery"></param>
        /// <returns>Grocery</returns>
        public async Task<Grocery> UpdateAsync(Grocery grocery)
        {
            Task<Grocery> grocerySku = _ctxt.Groceries.FirstOrDefaultAsync(y => y.Id == grocery.Id);
            if (grocerySku != null)
            {
                await _ctxt.SaveChangesAsync();
            }
            return grocery;
        }
    }
}