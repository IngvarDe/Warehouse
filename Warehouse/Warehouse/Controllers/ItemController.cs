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
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _itemServices.EditItem(id);

            return RedirectToAction(nameof(Edit), result);
        }

        [HttpPost]
        [Route(("api/Item/Add/{id}"))]
        public async Task<IActionResult> Add([FromBody] Item item)
        {
            var add = await _itemServices.Add(item);

            return RedirectToAction(nameof(Index), item);
        }

        [HttpDelete]
        [Route("api/Item/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var delete = await _itemServices.DeleteItem(id);

            if (delete == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), delete);
        }

        [HttpPut]
        [Route("api/Item/Update/{id}")]
        public async Task<IActionResult> Update(Item model)
        {
            var update = await _itemServices.UpdateItem(model);

            if (update == null)
            {
                return RedirectToAction(nameof(Index), model);
            }

            return RedirectToAction(nameof(Index), model);
        }
    }
}
