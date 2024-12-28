using Application.DTOs;
using Domain.Entities;

namespace Application.Ports
{
    public interface IReservaRepository
    {
        #region API
        Task<bool> IsDateRangeAvailableAsync(IsDateRangeAvailableDTO dto);
        Task<bool> IsDateRangeAvailableForUpdateAsync(UpdateDatesAsync dto); // IsDateRangeAvailableForUpdateDTO dto
        Task<IEnumerable<ResponseReservaDTO>> GetFilteredAsync(GetFilteredAsyncDTO dto);
        Task<Guid> AddAsync(Reserva reserva);        
        Task UpdateDatesAsync(UpdateDatesAsync dto);
        Task DeleteAsync(Guid id);
        #endregion

        #region CRUD
        Task<IEnumerable<Reserva>> GetAllAsync();
        Task<Reserva> GetByIdAsync(Guid id);        
        //Task UpdateAsync(Reserva reserva);        
        #endregion
    }
}
