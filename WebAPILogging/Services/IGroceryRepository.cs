using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiRestLogging.Models;

namespace WebApiRestLogging.Services
{
    /// <summary>
    /// IGroceryRepository
    /// </summary>
    public interface IGroceryRepository
    {
        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="grocery"></param>
        /// <returns>Grocery</returns>
        Task<Grocery> CreateAsync(Grocery grocery);

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="grocery"></param>
        /// <returns>void</returns>
        Task DeleteAsync(Grocery grocery);

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns>Grocery list</returns>
        Task<IEnumerable<Grocery>> GetAllAsync();

        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Grocery</returns>
        Task<Grocery> GetByIdAsync(int Id);

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="grocery"></param>
        /// <returns>Grocery</returns>
        Task<Grocery> UpdateAsync(Grocery grocery);
    }
}