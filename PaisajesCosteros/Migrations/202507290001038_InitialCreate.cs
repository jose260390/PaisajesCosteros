namespace PaisajesCosteros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "paisammg_user_admin.Imagens",
                c => new
                    {
                        Imagen_id = c.Int(nullable: false, identity: true),
                        Imagen_nombre = c.String(nullable: false),
                        Imagen_ruta = c.String(nullable: false),
                        Imagen_descripcion = c.String(),
                        Imagen_create_at = c.DateTime(nullable: false),
                        Imagen_update_at = c.DateTime(),
                        Usuario_id_fk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Imagen_id)
                .ForeignKey("paisammg_user_admin.Usuarios", t => t.Usuario_id_fk, cascadeDelete: true)
                .Index(t => t.Usuario_id_fk);
            
            CreateTable(
                "paisammg_user_admin.Usuarios",
                c => new
                    {
                        Usuario_id = c.Int(nullable: false, identity: true),
                        Usuario_nombre = c.String(nullable: false),
                        Usuario_email = c.String(nullable: false),
                        Usuario_pass = c.String(nullable: false),
                        Usuario_create_at = c.DateTime(nullable: false),
                        Usuario_update_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.Usuario_id);
            
            CreateTable(
                "paisammg_user_admin.PDFs",
                c => new
                    {
                        Pdf_id = c.Int(nullable: false, identity: true),
                        Pdf_nombre = c.String(nullable: false),
                        Pdf_ruta = c.String(nullable: false),
                        Pdf_descripcion = c.String(),
                        Pdf_create_at = c.DateTime(nullable: false),
                        Pdf_update_at = c.DateTime(),
                        Usuario_id_fk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pdf_id)
                .ForeignKey("paisammg_user_admin.Usuarios", t => t.Usuario_id_fk, cascadeDelete: true)
                .Index(t => t.Usuario_id_fk);
            
            CreateTable(
                "paisammg_user_admin.Videos",
                c => new
                    {
                        Video_id = c.Int(nullable: false, identity: true),
                        Video_nombre = c.String(nullable: false),
                        Video_ruta = c.String(nullable: false),
                        Video_descripcion = c.String(),
                        Video_create_at = c.DateTime(nullable: false),
                        Video_update_at = c.DateTime(),
                        Usuario_id_fk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Video_id)
                .ForeignKey("paisammg_user_admin.Usuarios", t => t.Usuario_id_fk, cascadeDelete: true)
                .Index(t => t.Usuario_id_fk);
            
        }
        
        public override void Down()
        {
            DropForeignKey("paisammg_user_admin.Imagens", "Usuario_id_fk", "paisammg_user_admin.Usuarios");
            DropForeignKey("paisammg_user_admin.Videos", "Usuario_id_fk", "paisammg_user_admin.Usuarios");
            DropForeignKey("paisammg_user_admin.PDFs", "Usuario_id_fk", "paisammg_user_admin.Usuarios");
            DropIndex("paisammg_user_admin.Videos", new[] { "Usuario_id_fk" });
            DropIndex("paisammg_user_admin.PDFs", new[] { "Usuario_id_fk" });
            DropIndex("paisammg_user_admin.Imagens", new[] { "Usuario_id_fk" });
            DropTable("paisammg_user_admin.Videos");
            DropTable("paisammg_user_admin.PDFs");
            DropTable("paisammg_user_admin.Usuarios");
            DropTable("paisammg_user_admin.Imagens");
        }
    }
}
