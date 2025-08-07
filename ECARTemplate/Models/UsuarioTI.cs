using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECARTemplate.Models
{
    public class UsuarioTI
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("NombreUsuario")]
        [Required(ErrorMessage = "Nombre de Usuario obligatorio")]
        [MaxLength(255)]
        [Display(Name = "Nombre Usuario")]
        public string NombreUsuario { get; set; }

        [Column("Usuario")]
        [Required(ErrorMessage = "Usuario obligatorio")]
        [MaxLength(50)]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Column("RolUsuario")]
        [Required(ErrorMessage = "Rol obligatorio")]
        [MaxLength(50)]
        [Display(Name = "Rol Usuario")]
        public string RolUsuario { get; set; }

        [Column("ContrasenaUsuario")]
        [Required(ErrorMessage = "Contraseña obligatoria")]
        [MaxLength(255)]
        [Display(Name = "Contraseña")]
        public string ContrasenaUsuario { get; set; }
       
    } 
}