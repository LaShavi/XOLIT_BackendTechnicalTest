using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspacioCompartidoController : ControllerBase
    {
        private readonly EspacioCompartidoService _service;

        public EspacioCompartidoController(EspacioCompartidoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspacioCompartido>>> GetAll()
        {
            var espacios = await _service.GetAllAsync();
            return Ok(espacios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EspacioCompartido>> GetById(Guid id)
        {
            var espacio = await _service.GetByIdAsync(id);
            if (espacio == null)
                return NotFound();

            return Ok(espacio);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateEspacioCompartidoDTO dto)
        {
            EspacioCompartido espacioCompartido = new EspacioCompartido();
            espacioCompartido.Id = Guid.NewGuid();
            espacioCompartido.NIT = dto.NIT;
            espacioCompartido.Nombre = dto.Nombre;
            espacioCompartido.Direccion = dto.Direccion;

            await _service.AddAsync(espacioCompartido);
            return CreatedAtAction(nameof(GetById), new { id = espacioCompartido.Id }, espacioCompartido);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, EspacioCompartido espacioCompartido)
        {            
            if (id != espacioCompartido.Id)
                return BadRequest();

            await _service.UpdateAsync(espacioCompartido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}