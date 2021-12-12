using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Domain;
using Warehouse.Core.ServiceInterface;

namespace Warehouse.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemServices _itemServices;

        public ItemController
            (
                IItemServices itemServices
            )
        {
            _itemServices = itemServices;
        }

        [HttpGet]
        [Route("api/Item/Index")]
        public IEnumerable<Item> Index()
        {
            var result = _itemServices.GetAllItems();

            return result;
        }

        [HttpGet]
        [Route("api/Item/Details/{id}")]
        public Item Edit(Guid id)
        {
            var result = _itemServices.EditItem(id);

            return result;
        }

        [HttpPost]
        [Route("api/Item/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var delete = await _itemServices.DeleteItem(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
