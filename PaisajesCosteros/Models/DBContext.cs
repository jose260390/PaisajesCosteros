using System.Data.Entity;

namespace PaisajesCosteros.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("paisammg_Entities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("paisammg_user_admin");
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Imagen> Imagenes { get; set; }
        public DbSet<PDF> PDFs { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Video> Videos { get; set; }
    }
}
