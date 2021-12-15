using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Domain;
using Warehouse.Core.Dtos;

namespace Warehouse.Core.ServiceInterface
{
    public interface IItemServices
    {
        IEnumerable<Item> GetAllItems();
        Task<Item> EditItem(Guid id);
        Task<Item> Add(Item item);
        Task<Item> DeleteItem(Guid id);
        Task<Item> UpdateItem(Item item);
    }
}
