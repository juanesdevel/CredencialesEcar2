namespace ECARTemplate.Models
{
    public class UsuarioTI
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Usuario { get; set; }
        public string RolUsuario { get; set; }
        public string ContrasenaUsuario { get; set; } // Aquí almacenaremos el hash
        // Otras propiedades si las necesitas
    }
}