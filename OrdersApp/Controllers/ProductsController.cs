using Microsoft.AspNetCore.Mvc;
using OrdersApp.Models;
using OrdersApp.Services;

namespace OrdersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return _productService.Get();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(string id)
        {
            var product = _productService.Get(id);
            if (product == null)
            {
                return NotFound($"Producto con Id={id} no se encontro");
            }
            return product;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            _productService.Create(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Product product)
        {
            var currentProduct = _productService.Get(id);
            if (currentProduct == null)
            {
                return NotFound($"Producto con Id={id} no se encontro");
            }
            _productService.Update(id, product);
            return Ok($"Se actualizo el producto con Id={id}");
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var currentProduct = _productService.Get(id);
            if (currentProduct == null)
            {
                return NotFound($"Producto con Id={id} no se encontro");
            }
            _productService.Delete(id);
            return Ok($"Se elimino el producto con Id={id}");
        }
    }
}
