using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Domain;
using Warehouse.Core.Dtos;
using Warehouse.Core.ServiceInterface;
using Warehouse.Data;

namespace Warehouse.ApplicationServices.Services
{
    public class ItemServices : IItemServices
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

        public async Task<Item> EditItem(Guid id)
        {
            var item = await _context.Items
                .FirstOrDefaultAsync(x => x.Id == id);

            return item;
        }

        public async Task<Item> Add(ItemDto dto)
        {
            Item item = new Item();


            item.Id = Guid.NewGuid();
            item.SerialNumber = dto.SerialNumber;
            item.Name = dto.Name;
            item.Weight = dto.Weight;
            item.Description = dto.Description;
            item.CreatedAt = DateTime.Now;
            item.ModifiedAt = DateTime.Now;

            //todo Location and Dimensions


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

        public async Task<Item> UpdateItem(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return item;
        }

    }
}
