using Microsoft.AspNetCore.Mvc;
using OrdersApp.Models;
using OrdersApp.Services;

namespace OrdersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            this._clientService = clientService;
        }

        // GET: api/<ClientsController>
        [HttpGet]
        public ActionResult<List<Client>> Get()
        {
            return _clientService.Get();
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get(string id)
        {
            var client = _clientService.Get(id);
            if (client == null)
            {
                return NotFound($"Cliente con Id={id} no se encontro");
            }
            return client;
        }

        // POST api/<ClientsController>
        [HttpPost]
        public ActionResult<Client> Post([FromBody] Client client)
        {
            _clientService.Create(client);
            return CreatedAtAction(nameof(Get), new { id = client.Id }, client);
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Client client)
        {
            var currentClient = _clientService.Get(id);
            if (currentClient == null)
            {
                return NotFound($"Cliente con Id={id} no se encontro");
            }
            _clientService.Update(id, client);
            return Ok($"Se actualizo el cliente con Id={id}");
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var currentClient = _clientService.Get(id);
            if (currentClient == null)
            {
                return NotFound($"Cliente con Id={id} no se encontro");
            }
            _clientService.Delete(id);
            return Ok($"Se elimino el cliente con Id={id}");
        }
    }
}
