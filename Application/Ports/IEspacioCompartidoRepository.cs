using Domain.Entities;

namespace Application.Ports
{
    public interface IEspacioCompartidoRepository
    {
        Task<IEnumerable<EspacioCompartido>> GetAllAsync();
        Task<EspacioCompartido> GetByIdAsync(Guid id);
        Task AddAsync(EspacioCompartido espacio);
        Task UpdateAsync(EspacioCompartido espacio);
        Task DeleteAsync(Guid id);
    }
}
