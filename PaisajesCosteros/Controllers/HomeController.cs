using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaisajesCosteros.Models;

namespace PaisajesCosteros.Controllers
{
    public class HomeController : Controller
    {
		private paisammg_Entities _db = new paisammg_Entities();

		public ActionResult Index()
        {
            return View();
		}

		[HttpPost]
        public ActionResult Imagen(string nombreCiudad)
        {
            try
            {
                List<Imagen> listaImagen =	_db.Imagen.Where(l => l.imagen_nombre == nombreCiudad).ToList();
                return View(listaImagen);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al obtener las imágenes. Detalle: " + ex.Message);
                return View(new List<Imagen>()); // Retorna una lista vacía en caso de error
            }
        }

        public ActionResult GalleryImage()
        {
			return View();
        }

        public ActionResult PDF()
		{
			try
			{
				return View(_db.PDF.ToList());
			}
			catch (Exception ex)
			{
				return View(_db.Imagen.ToList());
			}
		}

		public ActionResult Video()
		{
			try
			{
				return View(_db.Video.ToList());
			}
			catch (Exception ex)
			{
				return View(_db.Imagen.ToList());
			}
		}
	}
}