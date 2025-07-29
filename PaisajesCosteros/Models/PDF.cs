using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaisajesCosteros.Models
{
    public class PDF
    {
        [Key]
        public int Pdf_id { get; set; }

        [Required]
        public string Pdf_nombre { get; set; }

        [Required]
        public string Pdf_ruta { get; set; }

        public string Pdf_descripcion { get; set; }

        [Required]
        public DateTime Pdf_create_at { get; set; }

        public DateTime? Pdf_update_at { get; set; }

        [ForeignKey("Usuario")]
        public int Usuario_id_fk { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
