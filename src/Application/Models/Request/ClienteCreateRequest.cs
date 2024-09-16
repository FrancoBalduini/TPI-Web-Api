namespace Application.Models.Requests
{
    public class ClienteCreateRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NombreUser { get; set; } = string.Empty;
        
    }
}
