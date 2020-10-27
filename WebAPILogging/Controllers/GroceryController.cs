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
    /// GroceryController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryController : ControllerBase
    {
        private readonly IGroceryRepository _repo;
        private readonly ILogger<GroceryController> _logger;

        /// <summary>
        /// GroceryConroller Constructor
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="logger"></param>
        public GroceryController(IGroceryRepository repo, ILogger<GroceryController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        /// <summary>
        /// Get specific grocery object
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Grocery</returns>
        [HttpGet]
        [ActionName("GetGroceryById")]
        [Route("(api/Grocery/GetGroceryById/{Id}")]
        public async Task<IActionResult> GetGroceryById(int Id)
        {
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);

            var theGrocery = await _repo.GetByIdAsync(Id);
            return Ok(theGrocery);
        }

        /// <summary>
        /// Get list of groceries
        /// </summary>
        /// <returns>Groceris list</returns>
        [HttpGet]
        [Route("[action]")]
        [Route("(api/Grocery/GetAllGroceries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ActionName("GetAllGroceries")]
        public async Task<IActionResult> GetAllGroceries()
        {
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);

            var theGrocery = await _repo.GetAllAsync();
            return Ok(theGrocery);
        }

        /// <summary>
        /// Create Grocery
        /// </summary>
        /// <param name="grocery"></param>
        /// <returns>Http OK</returns>
        [HttpPost]
        [Route("[action]")]
        [Route("(api/Grocery/CreateGrocery")]
        [Produces("application/json", Type = typeof(Grocery))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ActionName("CreateGrocery")]
        public async Task<IActionResult> CreateGrocery(Grocery grocery)
        {
            _logger.LogInformation("You requested a method {MethodName} ", System.Reflection.MethodBase.GetCurrentMethod().Name);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            grocery.DateCreated = DateTime.UtcNow;
            grocery.CreatedBy = grocery?.CreatedBy ?? "System Ingestion";
            var theGrocery = await _repo.CreateAsync(grocery);
            return Ok(theGrocery);
        }

        /// <summary>
        /// Update Grocery
        /// </summary>
        /// <param name="grocery"></param>
        /// <returns>Http OK</returns>
        [HttpPut]
        [Route("[action]")]
        [Route("(api/Grocery/UpdateGrocery")]
        [ActionName("UpdateGrocery")]
        public async Task<IActionResult> UpdateGrocery(Grocery grocery)
        {
            _logger.LogInformation("You requested a method {MethodName} ", System.Reflection.MethodBase.GetCurrentMethod().Name);

            grocery.ModifiedBy = grocery?.ModifiedBy ?? "System Update";
            grocery.DateModified = DateTime.UtcNow;
            await _repo.UpdateAsync(grocery);
            return Ok(grocery);
        }

        /// <summary>
        /// DeleteGrocery
        /// </summary>
        /// <param name="grocery"></param>
        /// <returns>Http OK</returns>
        [HttpDelete]
        [Route("[action]")]
        [Route("(api/Grocery/DeleteGrocery")]
        [ActionName("DeleteGrocery")]
        public async Task<OkResult> DeleteGrocery(Grocery grocery)
        {
            _logger.LogInformation("You requested a method {MethodName} ", System.Reflection.MethodBase.GetCurrentMethod().Name);

            await _repo.DeleteAsync(grocery);
            return Ok();
        }
    }
}