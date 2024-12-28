using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaService _service;

        public ReservaController(ReservaService service)
        {
            _service = service;
        }

        #region API
        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<ResponseReservaDTO>>> GetFiltered(GetFilteredAsyncDTO dto)
        {
            var reservas = await _service.GetFilteredAsync(dto);
            return Ok(reservas);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateReservaDTO dto)
        {
            Reserva reserva = new Reserva();
            reserva.Id = Guid.NewGuid();
            reserva.FechaRegistro = dto.FechaRegistro;
            reserva.FechaIniReserva = dto.FechaIniReserva;
            reserva.FechaFinReserva = dto.FechaFinReserva;
            reserva.Estado = dto.Estado;
            reserva.ClienteId = dto.ClienteId;
            reserva.EspaciosCompartidosId = dto.EspaciosCompartidosId;

            if (reserva == null)
                return BadRequest("La información de la reserva es inválida.");

            var reservaId = await _service.AddAsync(reserva);
            return CreatedAtAction(nameof(GetById), new { id = reservaId }, reservaId);
        }

        [HttpPut("{id}/dates")]
        public async Task<ActionResult> UpdateDates(Guid id, [FromBody] UpdateDatesAsync reserva)
        {
            if (id != reserva.id)
                return BadRequest();

            await _service.UpdateDatesAsync(reserva);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        #endregion

        #region CRUD
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Reserva>>> GetAll()
        //{
        //    var reservas = await _service.GetAllAsync();
        //    return Ok(reservas);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetById(Guid id)
        {
            var reserva = await _service.GetByIdAsync(id);
            if (reserva == null)
                return NotFound();

            return Ok(reserva);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(Guid id, Reserva reserva)
        //{
        //    if (id != reserva.Id)
        //        return BadRequest();

        //    await _service.UpdateAsync(reserva);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(Guid id)
        //{
        //    await _service.DeleteAsync(id);
        //    return NoContent();
        //}
        #endregion
    }
}