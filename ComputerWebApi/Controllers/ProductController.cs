using ComputerWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> list = new List<Product>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {

                var result = list.SingleOrDefault(x => x.Id == Guid.Parse(id));
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(Product_VM model)
        {
            var newItem = new Product
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Category = model.Category,
                Price = model.Price
            };
            list.Add(newItem);

            return Ok(new
            {
                Status = true,
                Message = "Successful"
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Product newModel)
        {
            try
            {

                var result = list.SingleOrDefault(x => x.Id == Guid.Parse(id));
                if (result == null)
                {
                    return NotFound();
                }

                if (id != newModel.Id.ToString())
                {
                    return BadRequest();
                }

                result.Name = newModel.Name;
                result.Category = newModel.Category;
                result.Price = newModel.Price;
                return Ok(new
                {
                    Status = true,
                    Message = "Update Successful"
                });

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var result = list.SingleOrDefault(x => x.Id == Guid.Parse(id));
                if (result == null)
                {
                    return NotFound();
                }
                list.Remove(result);
                return Ok(new
                {
                    Status = true,
                    Message = "Delete Successful"
                });

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
