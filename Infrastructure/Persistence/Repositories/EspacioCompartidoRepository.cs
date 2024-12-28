using Application.Ports;
using Domain.Entities;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class EspacioCompartidoRepository : IEspacioCompartidoRepository
    {
        private readonly AppDbContext _context;

        public EspacioCompartidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EspacioCompartido>> GetAllAsync()
        {
            return await _context.EspacioCompartido
                .Select(e => new EspacioCompartido
                {
                    Id = e.Id,
                    NIT = e.NIT,
                    Nombre = e.Nombre,
                    Direccion = e.Direccion
                })
                .ToListAsync();
        }

        public async Task<EspacioCompartido?> GetByIdAsync(Guid id)
        {
            var entity = await _context.EspacioCompartido.FindAsync(id);
            return entity == null ? null : new EspacioCompartido
            {
                Id = entity.Id,
                NIT = entity.NIT,
                Nombre = entity.Nombre,
                Direccion = entity.Direccion
            };
        }

        public async Task AddAsync(EspacioCompartido espacioCompartido)
        {
            var entity = new EspacioCompartidoEntity
            {
                Id = espacioCompartido.Id,
                NIT = espacioCompartido.NIT,
                Nombre = espacioCompartido.Nombre,
                Direccion = espacioCompartido.Direccion
            };
            _context.EspacioCompartido.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EspacioCompartido espacioCompartido)
        {
            var entity = await _context.EspacioCompartido.FindAsync(espacioCompartido.Id);
            if (entity != null)
            {
                entity.NIT = espacioCompartido.NIT;
                entity.Nombre = espacioCompartido.Nombre;
                entity.Direccion = espacioCompartido.Direccion;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.EspacioCompartido.FindAsync(id);
            if (entity != null)
            {
                _context.EspacioCompartido.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}