using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.MyFirstService.Dtos;
using Service.MyFirstService.Entities;
using Service.MyFirstService.Repositories;

namespace Service.MyFirstService.Controllers.ProductsController
{
    //https://localhost:5001 /http://localhost:5000
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> productsRepository;

        public ProductsController(IRepository<Product> productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAsync()
        {
            var products = (await productsRepository.GetAllAsync())
                            .Select(product => product.AsDto());
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetByIdAsync(Guid id)
        {
            var product = await productsRepository.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product.AsDto();
        }

        // [HttpGet("{code}")]
        // public async Task<ActionResult<ProductDto>> GetByCodeAsync(int code)
        // {
        //     var product = await productsRepository.GetCodeAsync(code);

        //     if (product == null)
        //     {
        //         return NotFound();
        //     }

        //     return product.AsDto();
        // }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostAsync(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Code = createProductDto.Code,
                Name = createProductDto.Name,
                Amount = createProductDto.Amount,
                Category = createProductDto.Category,
                Image = createProductDto.Image,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await productsRepository.CreateAsync(product);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateProductDto updateProductDto)
        {
            var exsistingProduct = await productsRepository.GetAsync(id);

            if (exsistingProduct == null)
            {
                return NotFound();
            }


            exsistingProduct.Code = updateProductDto.Code;
            exsistingProduct.Name = updateProductDto.Name;
            exsistingProduct.Description = updateProductDto.Description;
            exsistingProduct.Price = updateProductDto.Price;
            exsistingProduct.Category = updateProductDto.Category;
            exsistingProduct.Amount = updateProductDto.Amount;
            exsistingProduct.Image = updateProductDto.Image;


            await productsRepository.UpdateAsync(exsistingProduct);

            return NoContent();
        }

        [HttpPut("{id}/update-quantity")]
        public async Task<IActionResult> UpdateQuantityAsync(Guid id, int newQuantity)
        {
            var existingProduct = await productsRepository.GetAsync(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Amount = newQuantity;

            await productsRepository.UpdateAsync(existingProduct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {

            var exsistingProduct = await productsRepository.GetAsync(id);

            if (exsistingProduct == null)
            {
                return NotFound();
            }

            await productsRepository.RemoveAsync(id);

            return NoContent();
        }

    }
}