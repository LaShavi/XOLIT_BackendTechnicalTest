using Application.DTOs;
using Application.Ports;
using Domain.Entities;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AppDbContext _context;

        public ReservaRepository(AppDbContext context)
        {
            _context = context;
        }

        #region API
        public async Task<bool> IsDateRangeAvailableAsync(IsDateRangeAvailableDTO dto)
        {
            return !await _context.Reservas.AnyAsync(r => r.EspaciosCompartidosId == dto.espacioId && r.FechaIniReserva < dto.fechaFinReserva && r.FechaFinReserva > dto.fechaIniReserva);
        }

        public async Task<bool> IsDateRangeAvailableForUpdateAsync(UpdateDatesAsync dto)
        {
            if (!dto.fechaIniReserva.HasValue || !dto.fechaFinReserva.HasValue)
                return true; 

            return !await _context.Reservas.AnyAsync(r => r.EspaciosCompartidosId == dto.espacioId && r.FechaIniReserva < dto.fechaFinReserva.Value && r.FechaFinReserva > dto.fechaIniReserva.Value);
        }

        /*
        public async Task<IEnumerable<Reserva>> GetFilteredAsync(GetFilteredAsyncDTO dto)
        {
            var query = _context.Reservas.AsQueryable();

            if (dto.fechaIniReserva.HasValue)
                query = query.Where(r => r.FechaIniReserva >= dto.fechaIniReserva.Value);

            if (dto.fechaFinReserva.HasValue)
                query = query.Where(r => r.FechaFinReserva <= dto.fechaFinReserva.Value);

            if (dto.clienteId.HasValue)
                query = query.Where(r => r.ClienteId == dto.clienteId.Value);

            if (dto.espaciosCompartidosId.HasValue)
                query = query.Where(r => r.EspaciosCompartidosId == dto.espaciosCompartidosId.Value);

            return await query.Select(r => new Reserva
            {
                Id = r.Id,
                FechaRegistro = r.FechaRegistro,
                FechaIniReserva = r.FechaIniReserva,
                FechaFinReserva = r.FechaFinReserva,
                Estado = r.Estado,
                ClienteId = r.ClienteId,
                EspaciosCompartidosId = r.EspaciosCompartidosId
            }).ToListAsync();
        }
        */
        public async Task<IEnumerable<ResponseReservaDTO>> GetFilteredAsync(GetFilteredAsyncDTO dto)
        {
            var query = _context.Reservas.AsQueryable();

            // Aplicar filtros opcionales
            if (dto.fechaIniReserva.HasValue)
                query = query.Where(r => r.FechaIniReserva >= dto.fechaIniReserva.Value);

            if (dto.fechaFinReserva.HasValue)
                query = query.Where(r => r.FechaFinReserva <= dto.fechaFinReserva.Value);

            if (dto.clienteId.HasValue)
                query = query.Where(r => r.ClienteId == dto.clienteId.Value);

            if (dto.espaciosCompartidosId.HasValue)
                query = query.Where(r => r.EspaciosCompartidosId == dto.espaciosCompartidosId.Value);

            // Realizar el Join con las tablas relacionadas y proyectar el nuevo modelo
            var result = await query
                .Join(
                    _context.Clientes, // Entidad Cliente
                    reserva => reserva.ClienteId, // Clave foránea en Reserva
                    cliente => cliente.Id, // Clave primaria en Cliente
                    (reserva, cliente) => new { Reserva = reserva, Cliente = cliente }
                )
                .Join(
                    _context.EspacioCompartido, // Entidad EspacioCompartido
                    reservaCliente => reservaCliente.Reserva.EspaciosCompartidosId, // Clave foránea en Reserva
                    espacio => espacio.Id, // Clave primaria en EspacioCompartido
                    (reservaCliente, espacio) => new ResponseReservaDTO
                    {
                        Id = reservaCliente.Reserva.Id,
                        FechaRegistro = reservaCliente.Reserva.FechaRegistro,
                        FechaIniReserva = reservaCliente.Reserva.FechaIniReserva,
                        FechaFinReserva = reservaCliente.Reserva.FechaFinReserva,
                        Estado = reservaCliente.Reserva.Estado,
                        ClienteId = reservaCliente.Cliente.Id,
                        ClienteNombre = $"{reservaCliente.Cliente.Nombre} {reservaCliente.Cliente.Apellido}",
                        EspaciosCompartidosId = espacio.Id,
                        EspaciosCompartidosNombre = espacio.Nombre
                    }
                )
                .ToListAsync();

            return result;
        }
        public async Task<Guid> AddAsync(Reserva reserva)
        {
            var entity = new ReservaEntity
            {
                Id = reserva.Id,
                FechaRegistro = reserva.FechaRegistro,
                FechaIniReserva = reserva.FechaIniReserva,
                FechaFinReserva = reserva.FechaFinReserva,
                Estado = reserva.Estado,
                ClienteId = reserva.ClienteId,
                EspaciosCompartidosId = reserva.EspaciosCompartidosId
            };
            _context.Reservas.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateDatesAsync(UpdateDatesAsync dto)
        {
            var entity = await _context.Reservas.FindAsync(dto.id);
            if (entity != null)
            {
                if (dto.fechaIniReserva.HasValue)
                    entity.FechaIniReserva = dto.fechaIniReserva.Value;

                if (dto.fechaFinReserva.HasValue)
                    entity.FechaFinReserva = dto.fechaFinReserva.Value;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Reservas.FindAsync(id);
            if (entity != null)
            {
                _context.Reservas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region CRUD
        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            return await _context.Reservas
                .Select(r => new Reserva
                {
                    Id = r.Id,
                    FechaRegistro = r.FechaRegistro,
                    FechaIniReserva = r.FechaIniReserva,
                    FechaFinReserva = r.FechaFinReserva,
                    Estado = r.Estado,
                    ClienteId = r.ClienteId,
                    EspaciosCompartidosId = r.EspaciosCompartidosId
                })
                .ToListAsync();
        }

        public async Task<Reserva?> GetByIdAsync(Guid id)
        {
            var entity = await _context.Reservas.FindAsync(id);
            return entity == null ? null : new Reserva
            {
                Id = entity.Id,
                FechaRegistro = entity.FechaRegistro,
                FechaIniReserva = entity.FechaIniReserva,
                FechaFinReserva = entity.FechaFinReserva,
                Estado = entity.Estado,
                ClienteId = entity.ClienteId,
                EspaciosCompartidosId = entity.EspaciosCompartidosId
            };
        }

        public async Task UpdateAsync(Reserva reserva)
        {
            var entity = await _context.Reservas.FindAsync(reserva.Id);
            if (entity != null)
            {
                entity.FechaIniReserva = reserva.FechaIniReserva;
                entity.FechaFinReserva = reserva.FechaFinReserva;
                entity.Estado = reserva.Estado;
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}