using HR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController1 : ControllerBase
    {
        private static List<SHOP> shop = new List<SHOP>
        {
            new SHOP  {Item  =1 , name = "Biscuit" , quantity = 100},
            new SHOP {Item  =2 , name = "Chips" , quantity = 150}
        };


        [HttpGet]
        public ActionResult<IEnumerable<SHOP>> GetAll()
        {
            return shop;
        }


        // GET: api/products/1
        [HttpGet("{id}")]
        public ActionResult<SHOP> GetById(int id)
        {
            var item = shop.FirstOrDefault(s => s.Item == id);
            if (item == null)
                return NotFound();
            return item;

        }


        // POST: api/shop
        [HttpPost]
        public ActionResult<SHOP> Create(SHOP newItem)
        {
            newItem.Item = shop.Any() ? shop.Max(s => s.Item) + 1 : 1;
            shop.Add(newItem);

            return CreatedAtAction(nameof(GetById), new { id = newItem.Item }, newItem);
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = shop.FirstOrDefault(s => s.Item == id);
            if (item == null)
                return NotFound();

            shop.Remove(item);
            return NoContent();
        }
    }
}

    