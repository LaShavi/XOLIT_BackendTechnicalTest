using Application.DTOs;
using Application.Ports;
using Domain.Entities;

namespace Application.Services
{
    public class ReservaService
    {
        private readonly IReservaRepository _repository;

        public ReservaService(IReservaRepository repository)
        {
            _repository = repository;
        }

        #region API
        public Task<IEnumerable<ResponseReservaDTO>> GetFilteredAsync(GetFilteredAsyncDTO dto)
        {
            return _repository.GetFilteredAsync(dto);
        }

        //public Task AddAsync(Reserva reserva) => _repository.AddAsync(reserva);
        public async Task<Guid> AddAsync(Reserva reserva)
        {
            IsDateRangeAvailableDTO response = new IsDateRangeAvailableDTO();
            response.espacioId = reserva.EspaciosCompartidosId;
            response.fechaIniReserva = reserva.FechaIniReserva;
            response.fechaFinReserva = reserva.FechaFinReserva;

            var isAvailable = await _repository.IsDateRangeAvailableAsync(response);

            if (!isAvailable)
            {
                throw new InvalidOperationException("El rango de fechas ya está reservado.");
            }

            return await _repository.AddAsync(reserva);
        }

        public async Task UpdateDatesAsync(UpdateDatesAsync dto)
        {
            //IsDateRangeAvailableForUpdateDTO response = new IsDateRangeAvailableForUpdateDTO();
            //response.id = dto.id;
            //response.espacioId = dto.espacioId;
            //response.fechaIniReserva = dto.fechaIniReserva;
            //response.fechaFinReserva = dto.fechaFinReserva;

            // Opcional: Verifica que al menos una de las fechas sea proporcionada.
            if (!dto.fechaIniReserva.HasValue && !dto.fechaFinReserva.HasValue)
                throw new ArgumentException("Debe proporcionar al menos una fecha para actualizar.");

            // Validación: Asegura que el rango de fechas no esté ocupado.
            var isAvailable = await _repository.IsDateRangeAvailableForUpdateAsync(dto);
            if (!isAvailable)
                throw new InvalidOperationException("El rango de fechas ya está reservado.");

            await _repository.UpdateDatesAsync(dto);
        }

        public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);
        #endregion

        #region CRUD
        public Task<IEnumerable<Reserva>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Reserva> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);
        
        //public Task UpdateAsync(Reserva reserva) => _repository.UpdateAsync(reserva);
        #endregion
    }
}