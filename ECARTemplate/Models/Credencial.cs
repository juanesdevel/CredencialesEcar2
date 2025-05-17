using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECARTemplate.Models
{
    [Table("Credenciales")]
    public class Credencial
    {
        [Key]
        public int Id { get; set; }

        [Column("codigo_equipo")]
        [Required(ErrorMessage = "El código de equipo es obligatorio.")]
        [StringLength(50)]
        public string CodigoEquipo { get; set; }

        [Column("fechaYhora")]
        [Required(ErrorMessage = "La fecha y hora son obligatorias.")]
        public DateTime FechaYHora { get; set; }

        [Column("codigo_usuario_ecar")]
        [Required(ErrorMessage = "El código de usuario es obligatorio.")]
        [StringLength(50)]
        public string CodigoUsuarioEcar { get; set; }

        [Column("nombre_usuario")]
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(255)]
        public string NombreUsuario { get; set; }

        [Column("perfil")]
        [Required(ErrorMessage = "El perfil es obligatorio.")]
        [StringLength(100)]
        public string Perfil { get; set; }

        [Column("usuario")]
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [StringLength(100)]
        public string Usuario { get; set; }

        [Column("contrasena")]
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(255)]
        public string Contrasena { get; set; }

        [Column("estado")]
        [Required(ErrorMessage = "El estado es obligatorio.")]
        [StringLength(50)]
        public string Estado { get; set; }

        [Column("usuario_registro")] // Cambiado el nombre de la columna
        [Required(ErrorMessage = "El usuario de registro es obligatorio.")]
        [StringLength(255)]
        public string UsuarioRegistro { get; set; } // Cambiado el nombre de la propiedad
    }
}