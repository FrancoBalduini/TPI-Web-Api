using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> GetAll() 
        {
            var cliente = _clienteService.GetAll();
            return Ok(cliente);
        }
        [HttpGet("{id}")]

        public ActionResult<Cliente> GetById(int id)
        {
            var cliente = _clienteService.GetById(id);
            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult<Cliente> Create([FromBody]Cliente cliente) 
        {
            var clienteCreado = _clienteService.Create(cliente);
            return Ok(clienteCreado);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id,[FromBody] Cliente cliente) 
        {
            _clienteService.Update(id, cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id) 
        {
            _clienteService.Delete(id);
            return NoContent();
        }
    }
}
