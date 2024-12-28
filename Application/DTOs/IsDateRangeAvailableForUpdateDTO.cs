namespace Application.DTOs
{
    public class IsDateRangeAvailableForUpdateDTO
    {
        // Guid id, Guid espacioId, DateTime? fechaIniReserva, DateTime? fechaFinReserva
        public Guid id { get; set; }
        public Guid espacioId { get; set; }
        public DateTime? fechaIniReserva { get; set; }
        public DateTime? fechaFinReserva { get; set; }
    }
}
