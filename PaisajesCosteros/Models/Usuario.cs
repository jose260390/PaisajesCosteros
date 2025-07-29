using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaisajesCosteros.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Imagen = new HashSet<Imagen>();
            PDF = new HashSet<PDF>();
            Video = new HashSet<Video>();
        }

        [Key]
        public int Usuario_id { get; set; }

        [Required]
        public string Usuario_nombre { get; set; }

        [Required]
        public string Usuario_email { get; set; }

        [Required]
        public string Usuario_pass { get; set; }

        [Required]
        public DateTime Usuario_create_at { get; set; }

        public DateTime? Usuario_update_at { get; set; }

        public virtual ICollection<Imagen> Imagen { get; set; }
        public virtual ICollection<PDF> PDF { get; set; }
        public virtual ICollection<Video> Video { get; set; }
    }
}
