using System;

namespace Service.MyFirstService.Entities
{

    public class Product : IEntity
    {
        public Guid Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        public int Amount { get; set; }

        public string Image { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}