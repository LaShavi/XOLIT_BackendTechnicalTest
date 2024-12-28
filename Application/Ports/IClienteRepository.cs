﻿using Domain.Entities;

namespace Application.Ports
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(Guid id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Guid id);
    }
}
