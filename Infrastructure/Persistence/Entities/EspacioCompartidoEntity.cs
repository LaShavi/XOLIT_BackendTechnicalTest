using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistence.Entities
{
    public class EspacioCompartidoEntity
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string NIT { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }
}
