namespace Domain.Entities
{
    public class EspacioCompartido
    {
        public Guid Id { get; set; }
        public string NIT { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }

    public class CreateEspacioCompartidoDTO
    {
        public string NIT { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }
}
