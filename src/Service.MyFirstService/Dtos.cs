using System;
using System.ComponentModel.DataAnnotations;

namespace Service.MyFirstService.Dtos
{
    public record ProductDto(Guid Id, int Code, string Name, string Description, double Price, string Category, int Amount, string Image, DateTimeOffset CreatedDate);

    public record CreateProductDto(string Name, int Code, string Description, [Range(0, Int32.MaxValue)] double Price, string Category, [Range(0, 100)] int Amount, string Image);

    public record UpdateProductDto(string Name, int Code, string Description, double Price, string Category, [Range(0, 100)] int Amount, string Image);
}
