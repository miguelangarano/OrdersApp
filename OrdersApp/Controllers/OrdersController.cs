using Microsoft.AspNetCore.Mvc;
using OrdersApp.Models;
using OrdersApp.Services;

namespace OrdersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return _orderService.Get();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(string id)
        {
            var order = _orderService.Get(id);
            if(order == null)
            {
                return NotFound($"Orden con Id={id} no se encontro");
            }
            return order;
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            _orderService.Create(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Order order)
        {
            var currentOrder = _orderService.Get(id);
            if (currentOrder == null)
            {
                return NotFound($"Orden con Id={id} no se encontro");
            }
            _orderService.Update(id, order);
            return Ok($"Se actualizo la orden con Id={id}");
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var currentOrder = _orderService.Get(id);
            if (currentOrder == null)
            {
                return NotFound($"Orden con Id={id} no se encontro");
            }
            _orderService.Delete(id);
            return Ok($"Se elimino la orden con Id={id}");
        }
    }
}
