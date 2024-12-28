using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistence.Entities
{
    public class ReservaEntity
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime FechaRegistro { get; set; }
        public DateTime FechaIniReserva { get; set; }
        public DateTime FechaFinReserva { get; set; }
        public int Estado { get; set; }
        public Guid ClienteId { get; set; }
        public Guid EspaciosCompartidosId { get; set; }
    }
}
