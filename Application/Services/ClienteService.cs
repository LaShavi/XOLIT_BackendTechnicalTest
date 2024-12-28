using Application.Ports;
using Domain.Entities;

namespace Application.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<IEnumerable<Cliente>> GetAllAsync() => _clienteRepository.GetAllAsync();
        public Task<Cliente> GetByIdAsync(Guid id) => _clienteRepository.GetByIdAsync(id);
        public Task AddAsync(Cliente cliente) => _clienteRepository.AddAsync(cliente);
        public Task UpdateAsync(Cliente cliente) => _clienteRepository.UpdateAsync(cliente);
        public Task DeleteAsync(Guid id) => _clienteRepository.DeleteAsync(id);
    }
}
