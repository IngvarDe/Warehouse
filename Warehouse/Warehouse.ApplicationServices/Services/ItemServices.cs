using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Domain;
using Warehouse.Data;

namespace Warehouse.ApplicationServices.Services
{
    public class ItemServices
    {
        private readonly WarehouseDbContext _context;

        public ItemServices
            (
                WarehouseDbContext context
            )
        {
            _context = context;
        }

        public IEnumerable<Item> GetAllItems()
        {

            var result = _context.Items
                .ToList()
                .OrderBy(x => x.Id);

            return result;
        }

        public Item EditItem(Guid id)
        {
            Item item = _context.Items.Find(id);

            return item;
        }

        public async Task<Item> DeleteItem(Guid id)
        {
            var item = await _context.Items
                .FirstOrDefaultAsync(x => x.Id == id);

            //Item item = _context.Items.Find(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }

    }
}
