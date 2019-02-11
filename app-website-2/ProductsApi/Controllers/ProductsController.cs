using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Model;
using ProductsApi.Store;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [Route("api/[controller]/{name}")]
    public class ProductsController : Controller
    {
        private readonly ProductStore _mProductStore;

        public ProductsController(ProductStore productStore)
        {
            _mProductStore = productStore;
        }

        [HttpGet]
        public IActionResult Get(string name)
        {
            if (name == null) return Ok(_mProductStore.GetAll());
            if (name.Equals("bad"))
            {
                return NotFound(name);
            }
            var product = _mProductStore.GetByName(name);
            if (product == null)
            {
                return NotFound(name);
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            if (_mProductStore.GetByName(value.Name) != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, value);
            }
            if (value.Name.Equals(""))
            {
                return NotFound(value);
            }
            _mProductStore.Add(value);
            return Created("api/Products", value);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product value)
        {
            var product = _mProductStore.GetByName(value.Name);
            if (product == null)
            {
                return NotFound(value);
            }
            _mProductStore.Delete(product);
            _mProductStore.Add(value);
            return Ok(value);
        }
    }
}
