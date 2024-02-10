using System;

namespace Service.MyFirstService.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}