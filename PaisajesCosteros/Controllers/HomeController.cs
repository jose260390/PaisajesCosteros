using System;
using System.Collections.Generic;
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

		public ActionResult Imagen()
		{
			try
			{
				return View(_db.Imagen.ToList());
			}
			catch (Exception ex)
			{
				return View(_db.Imagen.ToList());
			}
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