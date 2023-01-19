using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalesTracker.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IProductService _productService;
        public ItemController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] ProductCreate request)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            if (await _productService.CreateProductAsync(request))
            return Ok("Product created successfully.");

            return BadRequest("Product could not be created.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product is null)
                return NotFound();
            else
                return Ok(product);
        }
        
        [HttpPut]
        public async Task<IActionResult> EditProductById([FromBody] ProductEdit request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return await _productService.EditProductAsync(request)
                ? Ok("Game updated successfully.")
                : BadRequest("Game could note be updated.");
        }

        [HttpDelete("{productId:int}")]
        public async Task<IActionResult> ProductGame([FromRoute] int productId)
        {
            return await _productService.DeleteProductAsync(productId)
                ? Ok($"Note {productId} was deleted successfully.")
                : BadRequest($"Note {productId} could not be deleted.");
        }
    }
}