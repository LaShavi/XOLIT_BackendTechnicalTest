using Application.Ports;
using Domain.Entities;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{    
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes
                .Select(c => new Cliente
                {
                    Id = c.Id,
                    Cedula = c.Cedula,
                    Email = c.Email,
                    Telefono = c.Telefono,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido
                })
                .ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(Guid id)
        {
            var entity = await _context.Clientes.FindAsync(id);
            return entity == null ? null : new Cliente
            {
                Id = entity.Id,
                Cedula = entity.Cedula,
                Email = entity.Email,
                Telefono = entity.Telefono,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido
            };
        }

        public async Task AddAsync(Cliente cliente)
        {
            var entity = new ClienteEntity
            {
                Id = cliente.Id,
                Cedula = cliente.Cedula,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido
            };
            _context.Clientes.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            var entity = await _context.Clientes.FindAsync(cliente.Id);
            if (entity != null)
            {
                entity.Cedula = cliente.Cedula;
                entity.Email = cliente.Email;
                entity.Telefono = cliente.Telefono;
                entity.Nombre = cliente.Nombre;
                entity.Apellido = cliente.Apellido;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Clientes.FindAsync(id);
            if (entity != null)
            {
                _context.Clientes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
