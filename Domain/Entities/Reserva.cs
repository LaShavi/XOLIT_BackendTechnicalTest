namespace Domain.Entities
{
    public class Reserva
    {
        public Guid Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaIniReserva { get; set; }
        public DateTime FechaFinReserva { get; set; }
        public int Estado { get; set; }
        public Guid ClienteId { get; set; }
        public Guid EspaciosCompartidosId { get; set; }
    }

    public class CreateReservaDTO
    {        
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaIniReserva { get; set; }
        public DateTime FechaFinReserva { get; set; }
        public int Estado { get; set; }
        public Guid ClienteId { get; set; }
        public Guid EspaciosCompartidosId { get; set; }
    }

    public class ResponseReservaDTO
    {
        public Guid Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaIniReserva { get; set; }
        public DateTime FechaFinReserva { get; set; }
        public int Estado { get; set; }
        public Guid ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public Guid EspaciosCompartidosId { get; set; }
        public string EspaciosCompartidosNombre { get; set; }
    }
}
