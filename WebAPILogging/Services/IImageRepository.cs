using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiRestLogging.Models;

namespace WebApiRestLogging.Services
{
    /// <summary>
    /// IImageRepository
    /// </summary>
    public interface IImageRepository
    {
        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Image</returns>
        Task<Image> CreateAsync(Image image);

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="image"></param>
        /// <returns>void</returns>
        Task DeleteAsync(Image image);

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns>Image list</returns>
        Task<IEnumerable<Image>> GetAllAsync();

        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Image</returns>
        Task<Image> GetByIdAsync(int Id);

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Image</returns>
        Task<Image> UpdateAsync(Image image);
    }
}