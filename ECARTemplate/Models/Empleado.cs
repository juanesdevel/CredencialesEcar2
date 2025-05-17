using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECARTemplate.Models
{
    [Table("Empleados")]
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Column("codigo_empleado_ecar")]
        [Required]
        [StringLength(50)]
        public string CodigoEmpleadoEcar { get; set; }

        [Column("fecha")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Column("nombre_empleado")]
        [Required]
        [StringLength(255)]
        public string NombreEmpleado { get; set; }

        [Column("cargo")]
        [Required]
        [StringLength(100)]
        public string Cargo { get; set; }

        [Column("area")]
        [Required]
        [StringLength(100)]
        public string Area { get; set; }

        [Column("sub_area")]
        [Required]
        [StringLength(100)]
        public string SubArea { get; set; }

        [Column("nota")]
        public string Nota { get; set; }

        [Column("estado")]
        [Required]
        [StringLength(50)]
        public string Estado { get; set; }

        [Column("usuario_registro")]
        [Required]
        [StringLength(255)]
        public string UsuarioRegistro { get; set; }

        [Column("fecha_modificacion")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaModificacion { get; set; }

        [Column("firma_bpm")]
        [Required]
        [StringLength(20)]
        public string FirmaBpm { get; set; }
    }
}
