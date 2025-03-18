using PaisajesCosteros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PaisajesCosteros.Controllers
{
    public class HomeController : Controller
    {
        private readonly paisammg_Entities _db = new paisammg_Entities();

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Imagen(string nombreCiudad, int page = 1, int pageSize = 10)
        {
            try
            {
                if (string.IsNullOrEmpty(nombreCiudad))
                {
                    return Json(new { success = false, message = "El nombre de la ciudad no puede estar vacío." }, JsonRequestBehavior.AllowGet);
                }

                var query = _db.Imagen.Where(l => l.imagen_nombre == nombreCiudad);
                int totalImagenes = query.Count();

                if (totalImagenes == 0)
                {
                    return Json(new { success = false, message = "No se encontraron imágenes para esta ciudad." }, JsonRequestBehavior.AllowGet);
                }

                var listaImagen = query
                                    .OrderBy(l => l.imagen_id)
                                    .Skip((page - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();

                int totalPages = (int)Math.Ceiling((double)totalImagenes / pageSize);

                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = totalPages;
                ViewBag.NombreCiudad = nombreCiudad;

                // Si es una solicitud AJAX, devolver PartialView
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_ImagenesPaginadas", listaImagen);
                }

                // Si es una solicitud normal, devolver la vista completa
                return View(listaImagen);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en la acción Imagen: {ex.Message}");

                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false, message = "Ocurrió un error al obtener las imágenes." }, JsonRequestBehavior.AllowGet);
                }

                ModelState.AddModelError("", "Ocurrió un error al obtener las imágenes. Inténtelo de nuevo más tarde.");
                return View(new List<Imagen>());
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
                System.Diagnostics.Debug.WriteLine($"Error en la acción documentos: {ex.Message}");

                ModelState.AddModelError("", "Ocurrió un error al obtener los documentos. Inténtelo de nuevo más tarde.");
                return View(new List<Imagen>());
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