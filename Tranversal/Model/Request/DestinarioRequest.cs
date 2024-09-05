namespace Tranversal.Model.Request
{
    public class DestinarioRequest
    {
        public string ContactoNombre { get; set; }

        public Guid IdDireccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
    }
}
