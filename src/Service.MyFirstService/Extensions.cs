using Service.MyFirstService.Dtos;
using Service.MyFirstService.Entities;

namespace Service.MyFirstService
{
    public static class Extensions
    {
        public static ProductDto AsDto(this Product product)
        {
            return new ProductDto(product.Id, product.Code, product.Name, product.Description, product.Price, product.Category, product.Amount, product.Image, product.CreatedDate);
        }
    }
}