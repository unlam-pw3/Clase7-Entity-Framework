using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClaseEntityFramework.Controllers
{
    public class ProductosController : Controller
    {
        ProductoRepository prodRepository = new ProductoRepository();

        // GET: Productos
        public ActionResult Index()
        {
            List<Producto> productos = prodRepository.ObtenerTodos();
            return View(productos);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Producto prod)
        {
            prodRepository.Crear(prod);
            return RedirectToAction("Index");
        }
    }
}