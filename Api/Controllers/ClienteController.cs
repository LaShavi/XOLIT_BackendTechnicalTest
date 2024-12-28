using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(Guid id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateClienteDTO dto)
        {
            Cliente cliente = new Cliente();
            cliente.Id = Guid.NewGuid();
            cliente.Cedula = dto.Cedula;
            cliente.Email = dto.Email;
            cliente.Telefono = dto.Telefono;
            cliente.Nombre = dto.Nombre;
            cliente.Apellido = dto.Apellido;

            await _clienteService.AddAsync(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest();

            await _clienteService.UpdateAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _clienteService.DeleteAsync(id);
            return NoContent();
        }
    }
}
