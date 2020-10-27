using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApiRestLogging.Models;
using WebApiRestLogging.Services;

namespace WebApiRestLogging.Controllers
{
    /// <summary>
    /// ImageController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _repo;
        private readonly ILogger<ImageController> _logger;

        /// <summary>
        /// ImageConroller Constructor
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="logger"></param>
        public ImageController(IImageRepository repo, ILogger<ImageController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        /// <summary>
        /// Get specific image object
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Image</returns>
        [HttpGet]
        [ActionName("GetImageById")]
        [Route("(api/Image/GetImageById/{Id}")]
        public async Task<IActionResult> GetImageById(int Id)
        {
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);

            var theImage = await _repo.GetByIdAsync(Id);
            return Ok(theImage);
        }

        /// <summary>
        /// Get list of groceries
        /// </summary>
        /// <returns>Groceris list</returns>
        [HttpGet]
        [Route("[action]")]
        [Route("(api/Image/GetImages")]
        [ActionName("GetImages")]
        public async Task<IActionResult> GetImages()
        {
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);

            var theImage = await _repo.GetAllAsync();
            return Ok(theImage);
        }

        /// <summary>
        /// Create Image
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Http OK</returns>
        [HttpPost]
        [Route("[action]")]
        [Route("(api/Image/CreateImage")]
        [Produces("application/json", Type = typeof(Image))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ActionName("CreateImage")]
        public async Task<IActionResult> CreateImage(Image image)
        {
            _logger.LogInformation("You requested a method {MethodName} ", System.Reflection.MethodBase.GetCurrentMethod().Name);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            image.DateCreated = DateTime.UtcNow;
            image.CreatedBy = image?.CreatedBy ?? "System Ingestion";
            var theImage = await _repo.CreateAsync(image);
            return Ok(theImage);
        }

        /// <summary>
        /// Update Image
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Http OK</returns>
        [HttpPut]
        [Route("[action]")]
        [Route("(api/Image/UpdateImage")]
        [ActionName("UpdateImage")]
        public async Task<IActionResult> UpdateImage(Image image)
        {
            _logger.LogInformation("You requested a method {MethodName} ", System.Reflection.MethodBase.GetCurrentMethod().Name);

            image.ModifiedBy = image?.ModifiedBy ?? "System Update";
            image.DateModified = DateTime.UtcNow;
            await _repo.UpdateAsync(image);
            return Ok(image);
        }

        /// <summary>
        /// DeleteImage
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Http OK</returns>
        [HttpDelete]
        [Route("[action]")]
        [Route("(api/Image/DeleteImage")]
        [ActionName("DeleteImage")]
        public async Task<OkResult> DeleteImage(Image image)
        {
            _logger.LogInformation("You requested a method {MethodName} ", System.Reflection.MethodBase.GetCurrentMethod().Name);

            await _repo.DeleteAsync(image);
            return Ok();
        }
    }
}