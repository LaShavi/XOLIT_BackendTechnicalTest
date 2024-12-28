namespace Application.DTOs
{
    public class IsDateRangeAvailableDTO
    {
        public Guid espacioId { get; set; }
        public DateTime fechaIniReserva { get; set; }
        public DateTime fechaFinReserva { get; set; }
    }
}
