namespace Tranversal.Model.Request
{
    public class RemitenteRequest
    {
        public string NombreCompleto { get; set; }
        public string Departamento { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
        public string Identificacion { get; set; }

        public int TipoIdentificacion { get; set; }
        public Guid? Id { get; set; }
    }
}
