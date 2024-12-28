using Application.Ports;
using Domain.Entities;

namespace Application.Services
{
    public class EspacioCompartidoService
    {
        private readonly IEspacioCompartidoRepository _repository;

        public EspacioCompartidoService(IEspacioCompartidoRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<EspacioCompartido>> GetAllAsync() => _repository.GetAllAsync();

        public Task<EspacioCompartido> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

        public Task AddAsync(EspacioCompartido espacioCompartido) => _repository.AddAsync(espacioCompartido);

        public Task UpdateAsync(EspacioCompartido espacioCompartido) => _repository.UpdateAsync(espacioCompartido);

        public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);
    }
}
