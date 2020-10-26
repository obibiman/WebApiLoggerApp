using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRestLogging.Database;
using WebApiRestLogging.Models;

namespace WebApiRestLogging.Services
{
    /// <summary>
    /// ImageRepository
    /// </summary>
    public class ImageRepository : IImageRepository
    {
        private readonly GroceryContext _ctxt;

        /// <summary>
        /// ImageRepository Constructor
        /// </summary>
        /// <param name="ctxt"></param>
        public ImageRepository(GroceryContext ctxt)
        {
            _ctxt = ctxt;
        }

        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Image</returns>
        public async Task<Image> GetByIdAsync(int Id)
        {
            var imageSku = await _ctxt.Images.FirstOrDefaultAsync(y => y.Id == Id);
            return imageSku;
        }

        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Image</returns>
        public async Task<Image> CreateAsync(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }
            _ctxt.Set<Image>().Add(image);
            await _ctxt.SaveChangesAsync();
            return image;
        }

        /// <summary>
        /// DeleteAysnc
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Void</returns>
        public async Task DeleteAsync(Image image)
        {
            Task<Image> imageSku = _ctxt.Images.FirstOrDefaultAsync(y => y.Id == image.Id);

            if (imageSku != null)
            {
                var theId = imageSku.Id;
                _ctxt.Set<Image>().Remove(image);
            }
            await _ctxt.SaveChangesAsync();
        }

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns>List of Image</returns>
        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            List<Image> imageSku = await _ctxt.Images.ToListAsync();
            return imageSku;
        }

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Image</returns>
        public async Task<Image> UpdateAsync(Image image)
        {
            Task<Image> imageSku = _ctxt.Images.FirstOrDefaultAsync(y => y.Id == image.Id);
            if (imageSku != null)
            {
                await _ctxt.SaveChangesAsync();
            }
            return image;
        }
    }
}
