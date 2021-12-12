using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Domain;


namespace Warehouse.Core.ServiceInterface
{
    public interface IItemServices
    {
        IEnumerable<Item> GetAllItems();
        Task<Item> EditItem(Guid id);
        Task<Item> DeleteItem(Guid id);
        Task<Item> UpdateItem(Item item);
    }
}
