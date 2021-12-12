using System;
using System.Collections.Generic;
using Warehouse.Core.Domain;


namespace Warehouse.Core.ServiceInterface
{
    public interface IItemServices
    {
        IEnumerable<Item> GetAllItems();
        Item ReadItem(Guid id);
    }
}
