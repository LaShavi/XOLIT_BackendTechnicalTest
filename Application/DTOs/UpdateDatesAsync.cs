namespace Application.DTOs
{
    public class UpdateDatesAsync
    {
        public Guid id { get; set; }
        public Guid espacioId { get; set; }
        public DateTime? fechaIniReserva { get; set; }
        public DateTime? fechaFinReserva { get; set; }        
    }
}
