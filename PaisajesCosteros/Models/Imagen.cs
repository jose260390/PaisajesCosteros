using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaisajesCosteros.Models
{
    public class Imagen
    {
        [Key]
        public int Imagen_id { get; set; }

        [Required]
        public string Imagen_nombre { get; set; }

        [Required]
        public string Imagen_ruta { get; set; }

        public string Imagen_descripcion { get; set; }

        [Required]
        public DateTime Imagen_create_at { get; set; }

        public DateTime? Imagen_update_at { get; set; }

        [ForeignKey("Usuario")]
        public int Usuario_id_fk { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
