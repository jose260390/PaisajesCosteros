using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaisajesCosteros.Models
{
    public class Video
    {
        [Key]
        public int Video_id { get; set; }

        [Required]
        public string Video_nombre { get; set; }

        [Required]
        public string Video_ruta { get; set; }

        public string Video_descripcion { get; set; }

        [Required]
        public DateTime Video_create_at { get; set; }

        public DateTime? Video_update_at { get; set; }

        [ForeignKey("Usuario")]
        public int Usuario_id_fk { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
